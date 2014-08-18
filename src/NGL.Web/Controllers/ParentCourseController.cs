using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        
        private readonly IGenericRepository _genericRepository;
        private IMapper<CreateModel, ParentCourse> _createModelToParentCourseMapper;
        //
        // GET: /ParentCourse/
        public virtual ActionResult Index()
        {
            var parentCourses = new List<IndexModel>();
            return View(parentCourses);
        }

        //
        // GET: /ParentCourse/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
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
