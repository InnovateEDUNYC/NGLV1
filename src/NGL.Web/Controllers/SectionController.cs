using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
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
        private readonly IMapper<Course, CourseListItemModel> _courseToCourseListItemModelMapper;
        private readonly IMapper<CreateModel, Section> _createModelToSectionMapper;

        public SectionController(IGenericRepository genericRepository, 
            IMapper<Section, IndexModel> sectionToIndexModelMapper, 
            IMapper<ClassPeriod, ClassPeriodListItemModel> classPeriodToClassPeriodNameModelMapper, 
            IMapper<Location, LocationListItemModel> locationToClassRoomModelMapper, 
            IMapper<Course, CourseListItemModel> courseToCourseListItemModelMapper, 
            IMapper<CreateModel, Section> createModelToSectionMapper)
        {
            _genericRepository = genericRepository;
            _createModelToSectionMapper = createModelToSectionMapper;
            _sectionToIndexModelMapper = sectionToIndexModelMapper;
            _classPeriodToClassPeriodNameModelMapper = classPeriodToClassPeriodNameModelMapper;
            _locationToClassRoomModelMapper = locationToClassRoomModelMapper;
            _courseToCourseListItemModelMapper = courseToCourseListItemModelMapper;
        }

        // GET: /Section
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

        //
        // GET: /Section/Create
        public virtual ActionResult Create()
        {
            var classPeriodModels = GetClassPeriodNameModels();
            var classRoomModels = GetClassRoomModels();
            var courses = GetAllCourses();

            var createModel = CreateModel.CreateNewWith(classPeriodModels, classRoomModels, courses);
            return View(createModel);
        }

        // POST: /Section/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                createModel.Periods = GetClassPeriodNameModels();
                createModel.Classrooms = GetClassRoomModels();
                createModel.Courses = GetAllCourses();

                return View(createModel);
            }

            var section = _createModelToSectionMapper.Build(createModel);
            _genericRepository.Add(section);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
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

        private List<CourseListItemModel> GetAllCourses()
        {
            var courses = _genericRepository.GetAll<Course>();
            return courses.Select(course => _courseToCourseListItemModelMapper.Build(course)).ToList();
        } 
    }
}