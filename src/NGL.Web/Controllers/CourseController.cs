using System.Collections.Generic;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Course;

namespace NGL.Web.Controllers
{
    public partial class CourseController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<Course, CourseModel> _courseToCourseModelMapper;
        private readonly IMapper<CourseModel, Course> _courseModelToCourseMapper;

        public CourseController(IGenericRepository genericRepository, 
            IMapper<Course, CourseModel> courseToCourseModelMapper, 
            IMapper<CourseModel, Course> courseModelToCourseMapper)
        {
            _genericRepository = genericRepository;
            _courseToCourseModelMapper = courseToCourseModelMapper;
            _courseModelToCourseMapper = courseModelToCourseMapper;
        }


        // GET: /Course
        public virtual ActionResult Index()
        {

            IEnumerable<Course> courses = _genericRepository.GetAll<Course>();
            var courseModels = new List<CourseModel>();

            foreach (var course in courses)
            {
                var courseModel = new CourseModel();
                _courseToCourseModelMapper.Map(course, courseModel);
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
        public virtual ActionResult Create(CourseModel courseModel)
        {
            if (!ModelState.IsValid)
                return View(courseModel);

            var course = new Course();
            _courseModelToCourseMapper.Map(courseModel, course);

            _genericRepository.Add(course);
            _genericRepository.Save();

            return RedirectToAction("Index");
        }
    }
}