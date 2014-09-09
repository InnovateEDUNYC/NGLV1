using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Exceptions;
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
        private readonly IMapper<ParentCourse, ParentCourseListItemModel> _parentCourseToParentCourseListItemModelMapper;
        private readonly ICourseRepository _courseRepository;

        public CourseController(IGenericRepository genericRepository, 
            IMapper<Course, IndexModel> courseToIndexModelMapper, 
            IMapper<CreateModel, Course> createModelToCourseMapper, IMapper<ParentCourse, ParentCourseListItemModel> parentCourseToParentCourseListItemModelMapper, ICourseRepository courseRepository)
        {
            _genericRepository = genericRepository;
            _courseToIndexModelMapper = courseToIndexModelMapper;
            _createModelToCourseMapper = createModelToCourseMapper;
            _parentCourseToParentCourseListItemModelMapper = parentCourseToParentCourseListItemModelMapper;
            _courseRepository = courseRepository;
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
            var parentCourseList = GetParentCourseList();
            var createModel = CreateModel.CreateNewWith(parentCourseList);

            return View(createModel);
        }

        //POST: /Course/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                createModel.ParentCourseList = GetParentCourseList();
                return View(createModel);
            }

            var course = _createModelToCourseMapper.Build(createModel);
            _genericRepository.Add(course);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }

        private List<ParentCourseListItemModel> GetParentCourseList()
        {
            var parentCourseList = _genericRepository.GetAll<ParentCourse>().ToList();
            return parentCourseList.Select(parentCourse => _parentCourseToParentCourseListItemModelMapper.Build(parentCourse)).ToList();
        }

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            if (_courseRepository.HasDependencies(id))
            {
                TempData["Error"] = true;
                return RedirectToAction(MVC.Course.Index());
            }

            TempData["Error"] = false;
            try
            {
                _courseRepository.Delete(id);
            }
            catch (NglException)
            {
                TempData["Error"] = true;
            }

            return RedirectToAction(MVC.Course.Index());
        }
    }
}