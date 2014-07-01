using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;

namespace NGL.Web.Controllers
{
    public class SessionController : Controller
    {
        private readonly IGenericRepository _repository;

        public SessionController(IGenericRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Session/
        public ActionResult Index()
        {
            var sessions = _repository.Get<Session>(s => s.SessionName.Contains("soemthing"), s => s.Sections, s => s.School);
//            var sessionModels = sessionListToSessionModelList.Map(sessions, sessionModels);
//            return View(sessionModels);
            return View();
        }

        //
        // GET: /Session/Create/
        public ActionResult Create()
        {
            return View();
        }
        
        //
        // POST: /Session/Create/
        [HttpPost]
        public ActionResult Create(SessionModel sessionModel)
        {
            RedirectToAction("Index");
        }
	}
}