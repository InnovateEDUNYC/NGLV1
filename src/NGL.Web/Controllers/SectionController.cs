﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Section;
using CreateModel = NGL.Web.Models.Section.CreateModel;
using IndexModel = NGL.Web.Models.Section.IndexModel;

namespace NGL.Web.Controllers
{
    public partial class SectionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<Section, IndexModel> _sectionToIndexModelMapper;
        private readonly IMapper<ClassPeriod, ClassPeriodListItemModel> _classPeriodToClassPeriodNameModelMapper;
        private readonly IMapper<Location, LocationListItemModel> _locationToClassRoomModelMapper;
        private readonly IMapper<CreateModel, Section> _createModelToSectionMapper;
        private readonly IMapper<CreateModel, CourseOffering> _createModelToCourseOfferingMapper;
        private readonly IMapper<Session, SessionJsonModel> _sessionToSessionJSONModel;
        private readonly IMapper<Course, CourseJsonModel> _courseToCourseJsonModelMapper;

        public SectionController(IGenericRepository genericRepository, 
            IMapper<Section, IndexModel> sectionToIndexModelMapper, 
            IMapper<ClassPeriod, ClassPeriodListItemModel> classPeriodToClassPeriodNameModelMapper, 
            IMapper<Location, LocationListItemModel> locationToClassRoomModelMapper, 
            IMapper<CreateModel, Section> createModelToSectionMapper, 
            IMapper<CreateModel, CourseOffering> createModelToCourseOfferingMapper, 
            IMapper<Session, SessionJsonModel> sessionToSessionJsonModel, 
            IMapper<Course, CourseJsonModel> courseToCourseJsonModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToSectionMapper = createModelToSectionMapper;
            _createModelToCourseOfferingMapper = createModelToCourseOfferingMapper;
            _sessionToSessionJSONModel = sessionToSessionJsonModel;
            _courseToCourseJsonModelMapper = courseToCourseJsonModelMapper;
            _sectionToIndexModelMapper = sectionToIndexModelMapper;
            _classPeriodToClassPeriodNameModelMapper = classPeriodToClassPeriodNameModelMapper;
            _locationToClassRoomModelMapper = locationToClassRoomModelMapper;
        }

        // GET: /Section
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var sections = _genericRepository.GetAll<Section>();
            var indexModels = new List<IndexModel>();

            foreach (var section in sections)
            {
                var indexModel = new IndexModel();
                _sectionToIndexModelMapper.Map(section, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }

        // GET: /Section/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            var classPeriodModels = GetClassPeriodNameModels();
            var classRoomModels = GetClassRoomModels();

            var createModel = CreateModel.CreateNewWith(classPeriodModels, classRoomModels);
            return View(createModel);
        }

        // POST: /Section/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                createModel.Periods = GetClassPeriodNameModels();
                createModel.Classrooms = GetClassRoomModels();

                return View(createModel);
            }

            createSection(createModel);

            return RedirectToAction(Actions.Index());
        }

        [HttpPost]
        public virtual JsonResult GetSessions(string searchString)
        {
            var sessions = _genericRepository.GetAll<Session>()
                .Where(s => s.SessionName.ToLower().Contains(searchString.ToLower()));
            
            var sessionModels = sessions.Select(s => _sessionToSessionJSONModel.Build(s));
            return Json(sessionModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetCourses(string searchString)
        {
            var courses = _genericRepository.GetAll<Course>()
                .Where(c => ContainsCourseTitle(searchString, c) 
                    || ContainsCourseCode(searchString, c));

            var courseModels = courses.Select(c => _courseToCourseJsonModelMapper.Build(c));
            return Json(courseModels, JsonRequestBehavior.AllowGet);
        }

        private static bool ContainsCourseCode(string searchString, Course course)
        {
            return course.CourseCode.ToLower().Contains(searchString.ToLower());
        }

        private static bool ContainsCourseTitle(string searchString, Course course)
        {
            return course.CourseTitle.ToLower().Contains(searchString.ToLower());
        }

        private List<ClassPeriodListItemModel> GetClassPeriodNameModels()
        {
            var classPeriods = _genericRepository.GetAll<ClassPeriod>();
            return classPeriods.Select(classPeriod =>
                _classPeriodToClassPeriodNameModelMapper.Build(classPeriod)).ToList();
        }

        private List<LocationListItemModel> GetClassRoomModels()
        {
            var locations = _genericRepository.GetAll<Location>();
            return locations.Select(location => _locationToClassRoomModelMapper.Build(location)).ToList();
        }

        private void createSection(CreateModel createModel)
        {
            var section = _createModelToSectionMapper.Build(createModel);
            var courseOfferingByPrimaryKeysQuery = new CourseOfferingByPrimaryKeysQuery(createModel.Course,
                createModel.SchoolYear, createModel.Term);

            if (_genericRepository.Get(courseOfferingByPrimaryKeysQuery) == null)
            {
                var courseOffering = _createModelToCourseOfferingMapper.Build(createModel);
                _genericRepository.Add(courseOffering);
            }

            _genericRepository.Add(section);
            _genericRepository.Save();
        }
    }
}