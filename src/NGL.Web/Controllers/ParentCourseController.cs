using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
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
        private readonly IMapper<ParentCourse, ParentCourseJsonModel> _parentCourseToParentCourseJsonModelMapper;
        private readonly IMapper<ParentCourse, EditModel> _parentCourseToEditModelMapper;
        private readonly IMapper<EditModel, ParentCourse> _editModelToParentCourseMapper;

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<ParentCourse, ParentCourseJsonModel> parentCourseToParentCourseJsonModelMapper, IMapper<ParentCourse, EditModel> parentCourseToEditModelMapper, IMapper<EditModel, ParentCourse> editModelToParentCourseMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _parentCourseToParentCourseJsonModelMapper = parentCourseToParentCourseJsonModelMapper;
            _parentCourseToEditModelMapper = parentCourseToEditModelMapper;
            _editModelToParentCourseMapper = editModelToParentCourseMapper;
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

        //
        // GET: /ParentCourse/Edit
        [AuthorizeFor(Resource = "courseGeneration", Operation = "edit")]
        public virtual ActionResult Edit(Guid id)
        {
            var parentCourse = _parentCourseRepository.GetById(id);
            var editModel = _parentCourseToEditModelMapper.Build(parentCourse);
            return View(editModel);
        }

        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "edit")]
        public virtual ActionResult Edit(EditModel parentCourseEditModel)
        {
            if (!ModelState.IsValid)
                return View(parentCourseEditModel);

            var parentCourseToEdit = _parentCourseRepository.GetById(parentCourseEditModel.ParentCourseId);
            _editModelToParentCourseMapper.Map(parentCourseEditModel, parentCourseToEdit);
            _genericRepository.Save();

            return RedirectToAction(MVC.ParentCourse.Index());
        }

        [HttpPost]
        public virtual JsonResult GetParentCourses(string searchString)
        {
            var parentCourses = _genericRepository.GetAll<ParentCourse>().Where(pc => pc.ParentCourseTitle.ToLower().Contains(searchString.ToLower()) || pc.ParentCourseCode.ToLower().Contains(searchString.ToLower())).ToList();

            var parentCourseJsonModels = parentCourses.Select(p => _parentCourseToParentCourseJsonModelMapper.Build(p)).ToList();

            if (parentCourseJsonModels.IsNullOrEmpty())
            {
                parentCourseJsonModels.Add(new ParentCourseJsonModel { LabelName = "No results" });
            }

            return Json(parentCourseJsonModels, JsonRequestBehavior.AllowGet);
        }
    }
}
