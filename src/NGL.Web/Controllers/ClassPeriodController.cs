using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.ClassPeriod;

namespace NGL.Web.Controllers
{
    public partial class ClassPeriodController : Controller
    {
        private readonly IGenericRepository _genericRepository;

        public ClassPeriodController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: /ClassPeriod/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //POST: /ClassPeriod/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var classPeriod = new ClassPeriod();
//            _createModelToClassPeriodMapper.Map(createModel, classPeriod);
//
//            _genericRepository.Add(classPeriod);
//            _genericRepository.Save();

            return RedirectToAction("Index");
        }

	}
}