using System.Collections.Generic;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
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
        public virtual ActionResult Index()
        {

            IEnumerable<Course> courses = _genericRepository.GetAll<Course>();
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
        public virtual ActionResult Create()
        {
            return View();
        }

        //POST: /Course/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var course = new Course();
            _createModelToCourseMapper.Map(createModel, course);

            _genericRepository.Add(course);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }
    }
}