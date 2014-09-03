using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Exceptions;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.ClassPeriod;

namespace NGL.Web.Controllers
{
    public partial class ClassPeriodController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<CreateModel, ClassPeriod> _createModelToClassPeriodMapper;
        private readonly IMapper<ClassPeriod, IndexModel> _classPeriodToIndexModelMapper;
        private readonly IPeriodRepository _periodRepo;

        public ClassPeriodController(IGenericRepository genericRepository, 
            IMapper<CreateModel, ClassPeriod> createModelToClassPeriodMapper, 
            IMapper<ClassPeriod, IndexModel> classPeriodToIndexModelMapper, IPeriodRepository periodRepo)
        {
            _genericRepository = genericRepository;
            _createModelToClassPeriodMapper = createModelToClassPeriodMapper;
            _classPeriodToIndexModelMapper = classPeriodToIndexModelMapper;
            _periodRepo = periodRepo;
        }

        // GET: /ClassPeriod
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var classPeriods = _genericRepository.GetAll<ClassPeriod>().ToList();
            var indexModels = new List<IndexModel>();

            foreach (var classPeriod in classPeriods)
            {
                var indexModel = new IndexModel();
                _classPeriodToIndexModelMapper.Map(classPeriod, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }

        // GET: /ClassPeriod/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //POST: /ClassPeriod/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var classPeriod = new ClassPeriod();
            _createModelToClassPeriodMapper.Map(createModel, classPeriod);

            _genericRepository.Add(classPeriod);
            _genericRepository.Save();

            return RedirectToAction(MVC.ClassPeriod.Index());
        }

        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "delete")]
        public virtual ActionResult Delete(string classPeriodName)
        {
            TempData["ClassPeriodName"] = classPeriodName;

            var dependencies = _periodRepo.GetDependencyCount(classPeriodName);
            if (dependencies != 0)
            {
                TempData["ShowSuccess"] = false;
                return RedirectToAction(MVC.ClassPeriod.Index());
            }
            try
            {
                _periodRepo.Remove(classPeriodName);
            }
            catch (NglException)
            {
                TempData["ShowSuccess"] = false;
                return RedirectToAction(MVC.ClassPeriod.Index());
            }

            TempData["ShowSuccess"] = true;
            return RedirectToAction(MVC.ClassPeriod.Index());

        }
    }
}