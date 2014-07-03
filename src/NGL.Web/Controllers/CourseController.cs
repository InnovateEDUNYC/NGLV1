using System.Collections.Generic;
using System.Web.Mvc;
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

        public CourseController(IGenericRepository genericRepository, IMapper<Course, CourseModel> courseToCourseModelMapper)
        {
            _genericRepository = genericRepository;
            _courseToCourseModelMapper = courseToCourseModelMapper;
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
    }
}