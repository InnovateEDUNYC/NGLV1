using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.School;

namespace NGL.Web.Controllers
{
    public partial class SchoolController : Controller
    {
        private readonly IGenericRepository _genericRepository;

        public SchoolController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //
        // GET: /School/
        public virtual ActionResult Edit()
        {
            var school = _genericRepository.Get<EducationOrganization>(1);
            var schoolModel = new SchoolModel();
            new EducationOrganizationToSchoolModelMapper().Map(school, schoolModel);
            return View(schoolModel);
        }

        //
        // POST: /School/
        [HttpPost]
        public virtual ActionResult Edit(SchoolModel schoolModel)
        {
            if (!ModelState.IsValid)
                return View(schoolModel);

            var school = _genericRepository.Get<EducationOrganization>(1);
            new SchoolModelToEducationOrganizationMapper().Map(schoolModel, school);
            _genericRepository.Save();

            return RedirectToAction("Index", "Home");
        }
	}
}