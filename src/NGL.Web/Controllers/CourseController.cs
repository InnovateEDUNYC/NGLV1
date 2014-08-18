using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Course;

namespace NGL.Web.Controllers
{
    public partial class CourseController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<Course, IndexModel> _courseToIndexModelMapper;
        private readonly IMapper<CreateModel, Course> _createModelToCourseMapper;

        public CourseController(IGenericRepository genericRepository, 
            IMapper<Course, IndexModel> courseToIndexModelMapper, 
            IMapper<CreateModel, Course> createModelToCourseMapper)
        {
            _genericRepository = genericRepository;
            _courseToIndexModelMapper = courseToIndexModelMapper;
            _createModelToCourseMapper = createModelToCourseMapper;
        }


        // GET: /Course
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            IEnumerable<Course> courses = _genericRepository.GetAll<Course>().ToList();
            var indexModels = new List<IndexModel>();

            foreach (var course in courses)
            {
                var indexModel = new IndexModel();
                _courseToIndexModelMapper.Map(course, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }

        // GET: /Course/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //POST: /Course/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var course = _createModelToCourseMapper.Build(createModel);
            _genericRepository.Add(course);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }
    }
}