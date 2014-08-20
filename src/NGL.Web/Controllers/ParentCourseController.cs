using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration.Internal;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        private readonly IMapper<CreateModel, ParentCourse> _createModelToParentCourseMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<ParentCourse, IndexModel> _parentCourseToIndexModelMapper;
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly IMapper<Section, FindParentCourseModel> _sectionToFindParentCourseModelMapper;

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<Section, FindParentCourseModel> sectionToFindParentCourseModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
        }
        //
        // GET: /ParentCourse/
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var parentCourses = _parentCourseRepository.GetParentCourses();

            var indexModels = parentCourses.Select(pc => _parentCourseToIndexModelMapper.Build(pc));

            return View(indexModels);
        }

        //
        // GET: /ParentCourse/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ParentCourse/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var parentCourse = _createModelToParentCourseMapper.Build(createModel);
            _genericRepository.Add(parentCourse);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }

        // GET: /ParentCourse/Grades
        public virtual ActionResult Grades(int? sectionId = null)
        {
            if (sectionId == null) 
                return View();

            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == sectionId); ;
            var course = _genericRepository.Get<Course>(c => c.CourseCode == section.LocalCourseCode);
            var parentCourse = _genericRepository.Get<ParentCourse>( pc => pc.Id == course.ParentCourseId);
//            var grades = _genericRepository.GetAll<Grade>( grade => grade.ParentCourseId); //sql migration script todo

            var findParentCourseModel = _sectionToFindParentCourseModelMapper.Build(section); //perhaps just populate this from the section info?

//            var parentGradesModelList = _parentCourseToParentGradesModelMapper.Build(parentCourse);
//            return View(Tuple.Create(findParentCourseModel, parentGradesModelList));
            return View();
        }
    }
}
