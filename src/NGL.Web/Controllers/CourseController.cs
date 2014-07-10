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
        private readonly IMapper<Course, CreateModel> _courseToCreateModelMapper;
        private readonly IMapper<CreateModel, Course> _createModelToCourseMapper;

        public CourseController(IGenericRepository genericRepository, 
            IMapper<Course, CreateModel> courseToCreateModelMapper, 
            IMapper<CreateModel, Course> createModelToCourseMapper)
        {
            _genericRepository = genericRepository;
            _courseToCreateModelMapper = courseToCreateModelMapper;
            _createModelToCourseMapper = createModelToCourseMapper;
        }


        // GET: /Course
        public virtual ActionResult Index()
        {

            IEnumerable<Course> courses = _genericRepository.GetAll<Course>();
            var courseModels = new List<CreateModel>();

            foreach (var course in courses)
            {
                var courseModel = new CreateModel();
                _courseToCreateModelMapper.Map(course, courseModel);
                courseModels.Add(courseModel);
            }

            return View(courseModels);
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
            CheckIfExists(createModel);
            if (!ModelState.IsValid)
                return View(createModel);

            var course = new Course();
            _createModelToCourseMapper.Map(createModel, course);

            _genericRepository.Add(course);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }

        private void CheckIfExists(CreateModel createModel)
        {
            if (createModel.CourseCode != null)
            {
                var existingSession = _genericRepository.Get(new CourseByCourseCodeQuery(
                    createModel.CourseCode));

                if (existingSession != null)
                {
                    PutModelErrors();
                }
            }
        }

        private void PutModelErrors()
        {
            ModelState.AddModelError("coursecode", "This course already exists!");
        }
    }
}