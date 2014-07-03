using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.School;

namespace NGL.Web.Controllers
{
    public partial class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper<SchoolModel, EducationOrganization> _toEntityMapper;
        private readonly IMapper<EducationOrganization, SchoolModel> _toVmMapper;

        public SchoolController(
            ISchoolRepository schoolRepository, 
            IMapper<SchoolModel, EducationOrganization> toEntityMapper, 
            IMapper<EducationOrganization, SchoolModel> toVmMapper)
        {
            _schoolRepository = schoolRepository;
            _toEntityMapper = toEntityMapper;
            _toVmMapper = toVmMapper;
        }

        //
        // GET: /School/
        public virtual ActionResult Edit()
        {
            var educationOrg = _schoolRepository.GetSchool().EducationOrganization;
            var schoolModel = new SchoolModel();
            _toVmMapper.Map(educationOrg, schoolModel);
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
            _toEntityMapper.Map(schoolModel, school);
            _schoolRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }
	}
}