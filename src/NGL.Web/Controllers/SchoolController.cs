using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.School;

namespace NGL.Web.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IGenericRepository _genericRepository;

        public SchoolController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //
        // GET: /School/
        public ActionResult Edit()
        {
            var school = _genericRepository.Get<EducationOrganization>(1, eo => eo.School);
            var schoolModel = new SchoolModel();
            new SchoolModelToEducationOrganizationMapper().Map(school, schoolModel);
            return View(schoolModel);
        }
	}
}