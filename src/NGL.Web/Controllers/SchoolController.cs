using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.School;

namespace NGL.Web.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly NglDbContext _nglDbContext;

        public SchoolController()
        {
            // ToDo: This is just to get the code working
            // I am going to change it to be injected by IoC container
            _nglDbContext = new NglDbContext();
            _genericRepository = new GenericRepository(_nglDbContext);
        }

        //
        // GET: /School/
        public ActionResult Edit()
        {
            var school = _genericRepository.Get<EducationOrganization>(1);
            var schoolModel = new SchoolModel();
            new EducationOrganizationToSchoolModelMapper().Map(school, schoolModel);
            return View(schoolModel);
        }

        //
        // POST: /School/
        [HttpPost]
        public ActionResult Edit(SchoolModel schoolModel)
        {
            if (!ModelState.IsValid)
                return View(schoolModel);

            var school = _genericRepository.Get<EducationOrganization>(1);
            new SchoolModelToEducationOrganizationMapper().Map(schoolModel, school);
            _nglDbContext.Save();

            return RedirectToAction("Index", "Home");
        }
	}
}