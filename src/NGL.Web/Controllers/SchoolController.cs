using System.Web.Mvc;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.School;

namespace NGL.Web.Controllers
{
    public partial class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        //
        // GET: /School/
        public virtual ActionResult Edit()
        {
            var educationOrg = _schoolRepository.GetSchool().EducationOrganization;
            var schoolModel = new SchoolModel();
            new EducationOrganizationToSchoolModelMapper().Map(educationOrg, schoolModel);
            return View(schoolModel);
        }

        //
        // POST: /School/
        [HttpPost]
        public virtual ActionResult Edit(SchoolModel schoolModel)
        {
            if (!ModelState.IsValid)
                return View(schoolModel);

            var school = _schoolRepository.GetSchool().EducationOrganization;
            new SchoolModelToEducationOrganizationMapper().Map(schoolModel, school);
            _schoolRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }
	}
}