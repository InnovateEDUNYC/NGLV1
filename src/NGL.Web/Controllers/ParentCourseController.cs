using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Configuration.Internal;
using System.Web.Mvc;
using Castle.Core.Internal;
using Humanizer;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;
using Microsoft.WindowsAzure.Storage.Table;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using NGL.Web.Models.ParentCourse;
using CreateModel = NGL.Web.Models.ParentCourse.CreateModel;
using IndexModel = NGL.Web.Models.ParentCourse.IndexModel;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        private readonly IMapper<CreateModel, ParentCourse> _createModelToParentCourseMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<ParentCourse, IndexModel> _parentCourseToIndexModelMapper;
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly IMapper<Section, ParentCourseGrade> _sectionToParentCourseGradeMapper;
        private readonly StudentsToParentCourseGradesModelMapper _studentsToParentCourseGradesModelMapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper<ParentCourse, ParentCourseJsonModel> _parentCourseToParentCourseJsonModelMapper;

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<ParentCourseGrade, FindParentCourseModel> parentCourseGradeToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper, IMapper<Section, ParentCourseGrade> sectionToParentCourseGradeMapper, ISectionRepository sectionRepository, IMapper<ParentCourse, ParentCourseJsonModel> parentCourseToParentCourseJsonModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToParentCourseGradeMapper = sectionToParentCourseGradeMapper;
            _sectionRepository = sectionRepository;
            _parentCourseToParentCourseJsonModelMapper = parentCourseToParentCourseJsonModelMapper;
            _studentsToParentCourseGradesModelMapper = new StudentsToParentCourseGradesModelMapper(parentCourseGradeToFindParentCourseModelMapper, parentCourseGradeToGradeModelMapper, studentToGradeModelMapper);
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


        [HttpPost]
        public virtual JsonResult GetParentCourses(string searchString)
        {
            var parentCourses = _genericRepository.GetAll<ParentCourse>().Where(pc => pc.ParentCourseTitle.ToLower().Contains(searchString.ToLower())).ToList();

            var parentCourseJsonModels = parentCourses.Select(p => _parentCourseToParentCourseJsonModelMapper.Build(p)).ToList();

            if (parentCourseJsonModels.IsNullOrEmpty())
            {
                parentCourseJsonModels.Add(new ParentCourseJsonModel { LabelName = "No results" });
            }

            return Json(parentCourseJsonModels, JsonRequestBehavior.AllowGet);
        }
    }
}
