using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Data.Repositories;
using NGL.Web.Exceptions;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Section;
using NGL.Web.Models.Session;
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
        private readonly IMapper<Session, SessionJsonModel> _sessionToSessionJsonModelMapper;
        private readonly IMapper<Course, CourseJsonModel> _courseToCourseJsonModelMapper;
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper<Session, SessionWithSectionsModel> _sessionToSessionWithSectionsModelMapper;
        private readonly ISectionRepository _sectionRepository;

        public SectionController(IGenericRepository genericRepository, 
            IMapper<Section, IndexModel> sectionToIndexModelMapper, 
            IMapper<ClassPeriod, ClassPeriodListItemModel> classPeriodToClassPeriodNameModelMapper, 
            IMapper<Location, LocationListItemModel> locationToClassRoomModelMapper, 
            IMapper<CreateModel, Section> createModelToSectionMapper, 
            IMapper<CreateModel, CourseOffering> createModelToCourseOfferingMapper, 
            IMapper<Session, SessionJsonModel> sessionToSessionJsonModelMapper, 
            IMapper<Course, CourseJsonModel> courseToCourseJsonModelMapper, 
            ISessionRepository sessionRepository, IMapper<Session, SessionWithSectionsModel> sessionToSessionWithSectionsModelMapper, 
            ISectionRepository sectionRepository)
        {
            _genericRepository = genericRepository;
            _createModelToSectionMapper = createModelToSectionMapper;
            _createModelToCourseOfferingMapper = createModelToCourseOfferingMapper;
            _sessionToSessionJsonModelMapper = sessionToSessionJsonModelMapper;
            _courseToCourseJsonModelMapper = courseToCourseJsonModelMapper;
            _sessionRepository = sessionRepository;
            _sessionToSessionWithSectionsModelMapper = sessionToSessionWithSectionsModelMapper;
            _sectionRepository = sectionRepository;
            _sectionToIndexModelMapper = sectionToIndexModelMapper;
            _classPeriodToClassPeriodNameModelMapper = classPeriodToClassPeriodNameModelMapper;
            _locationToClassRoomModelMapper = locationToClassRoomModelMapper;
        }

        // GET: /Section
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var sections = _genericRepository.GetAll<Section>().ToList();
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
        public virtual ActionResult Create(int? sessionIdentity)
        {
            var session = sessionIdentity.HasValue ? _sessionRepository.GetById(sessionIdentity.Value) : null; 
            var classPeriodModels = GetClassPeriodNameModels();
            var classRoomModels = GetClassRoomModels();

            var createModel = CreateModel.CreateNewWith(classPeriodModels, classRoomModels, session);

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

            CreateSection(createModel);

            return RedirectToAction(Actions.Index());
        }

        [HttpPost]
        public virtual JsonResult GetSessions(string searchString)
        {
            var sessions = _genericRepository.GetAll<Session>()
                .Where(s => s.SessionName.ToLower().Contains(searchString.ToLower())).ToList();
            
            var sessionModels = sessions.Select(s => _sessionToSessionJsonModelMapper.Build(s)).ToList();

            if (sessionModels.IsNullOrEmpty())
            {
                sessionModels.Add(new SessionJsonModel{SessionName = "No results"});
            }

            return Json(sessionModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetCourses(string searchString)
        {
            var courses = _genericRepository.GetAll<Course>()
                .Where(c => ContainsCourseTitle(searchString, c) 
                    || ContainsCourseCode(searchString, c)).ToList();

            var courseModels = courses.Select(c => _courseToCourseJsonModelMapper.Build(c));
            return Json(courseModels, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeFor(Resource = "session", Operation = "view")]
        public virtual ActionResult ForSession(int id)
        {
            var session = _sessionRepository.GetWithSectionsById(id);
            var sessionWithSectionsModel = _sessionToSessionWithSectionsModelMapper.Build(session);

            return View(sessionWithSectionsModel);
        }

        public virtual ActionResult Delete(int sectionIdentity)
        {
            if (_sectionRepository.HasDependencies(sectionIdentity))
            {
                TempData["ShowSuccess"] = false;
                return RedirectToAction(MVC.Section.Index());
            }

            try
            {
                _sectionRepository.Remove(sectionIdentity);
            }
            catch (NglException)
            {
                TempData["ShowSuccess"] = false;
                return RedirectToAction(MVC.Section.Index());
            }

            TempData["ShowSuccess"] = true;
            return RedirectToAction(MVC.Section.Index());
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
            var classPeriods = _genericRepository.GetAll<ClassPeriod>().ToList();
            return classPeriods.Select(classPeriod =>
                _classPeriodToClassPeriodNameModelMapper.Build(classPeriod)).ToList();
        }

        private List<LocationListItemModel> GetClassRoomModels()
        {
            var locations = _genericRepository.GetAll<Location>().ToList();
            return locations.Select(location => _locationToClassRoomModelMapper.Build(location)).ToList();
        }

        private void CreateSection(CreateModel createModel)
        {
            var section = _createModelToSectionMapper.Build(createModel);
            var session = _genericRepository.Get<Session>(s => s.SessionIdentity == createModel.SessionId);

            var courseOfferingByPrimaryKeysQuery = new CourseOfferingByPrimaryKeysQuery(createModel.Course,
                session.SchoolYear, session.TermTypeId);

            if (CourseOfferingNeedsToBeCreated(courseOfferingByPrimaryKeysQuery))
            {
                var courseOffering = _createModelToCourseOfferingMapper.Build(createModel);
                _genericRepository.Add(courseOffering);
            }

            _genericRepository.Add(section);
            _genericRepository.Save();
        }

        private bool CourseOfferingNeedsToBeCreated(CourseOfferingByPrimaryKeysQuery courseOfferingByPrimaryKeysQuery)
        {
            return _genericRepository.Get(courseOfferingByPrimaryKeysQuery) == null;
        }
    }
}