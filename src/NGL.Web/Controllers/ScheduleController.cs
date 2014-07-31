using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
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
        private readonly IMapper<Session, SessionListItemModel> _sessionToSessionListItemModelMapper;

        public ScheduleController(IGenericRepository genericRepository, ProfilePhotoUrlFetcher profilePhotoUrlFetcher, IMapper<Session, SessionListItemModel> sessionToSessionListItemModelMapper)
        {
            _genericRepository = genericRepository;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
            _sessionToSessionListItemModelMapper = sessionToSessionListItemModelMapper;
        }

        //
        // GET: /Set/5
        public virtual ActionResult Set(int id)
        {
            var student = _genericRepository.Get<Student>(s => s.StudentUSI == id);
            var profilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(student);
            var sessions = GetAllSessions();

            var defaultSessionListModel = _sessionToSessionListItemModelMapper.Build(new SessionFilter(_genericRepository).FindSession(DateTime.Now));
            var setModel = SetModel.CreateNewWith(student, profilePhotoUrl, sessions, defaultSessionListModel);
            return View(setModel);
        }

        [HttpPost]
        public virtual JsonResult GetSections(string searchString)
        {
            var sections = _genericRepository.GetAll<Section>();
            return Json(sections, JsonRequestBehavior.AllowGet);
        }

        private List<SessionListItemModel> GetAllSessions()
        {
            var sessions = _genericRepository.GetAll<Session>();
            return sessions.Select(session => _sessionToSessionListItemModelMapper.Build(session)).ToList();
        }
	}
}