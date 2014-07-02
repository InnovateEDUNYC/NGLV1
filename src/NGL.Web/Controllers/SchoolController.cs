using System.Linq;
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
            // ToDoMK
            var school = _genericRepository.GetAll<EducationOrganization>().FirstOrDefault();
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

            // ToDoMK
            var school = _genericRepository.GetAll<EducationOrganization>().FirstOrDefault();
            new SchoolModelToEducationOrganizationMapper().Map(schoolModel, school);
            _genericRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }
	}
}