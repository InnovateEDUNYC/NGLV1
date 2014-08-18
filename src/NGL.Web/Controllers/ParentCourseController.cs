using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        private readonly IMapper<CreateModel, ParentCourse> _createModelToParentCourseMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<ParentCourse, IndexModel> _parentCourseToIndexModelMapper;
        private IParentCourseRepository _parentCourseRepository;

        public ParentCourseController(IGenericRepository genericRepository,
            IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
        }
        //
        // GET: /ParentCourse/
        public virtual ActionResult Index()
        {
            var parentCourses = _parentCourseRepository.GetParentCourses();

            var indexModels = parentCourses.Select(pc => _parentCourseToIndexModelMapper.Build(pc));

            return View(indexModels);
        }

        //
        // GET: /ParentCourse/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ParentCourse/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            var parentCourse = _createModelToParentCourseMapper.Build(createModel);
            _genericRepository.Add(parentCourse);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }
    }
}
