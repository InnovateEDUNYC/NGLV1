using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class ScheduleController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        public ScheduleController(IGenericRepository genericRepository, ProfilePhotoUrlFetcher profilePhotoUrlFetcher)
        {
            _genericRepository = genericRepository;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
        }

        //
        // GET: /Set/5
        public virtual ActionResult Set(int id)
        {
            var student = _genericRepository.Get<Student>(s => s.StudentUSI == id);
            var profilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(student);

            var setModel = SetModel.CreateNewWith(student, profilePhotoUrl);
            return View(setModel);
        }
	}
}