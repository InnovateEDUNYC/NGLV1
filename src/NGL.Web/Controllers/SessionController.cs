using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Session;

namespace NGL.Web.Controllers
{
    public partial class SessionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISchoolRepository _schoolRepository;

        public SessionController(IGenericRepository genericRepository, ISchoolRepository schoolRepository)
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
        }

        // GET: Session
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(SessionModel sessionModel)
        {
            if (!ModelState.IsValid)
                return View(sessionModel);

            var session = new Session();
            new SessionModelToSessionMapper(_schoolRepository).Map(sessionModel, session);
            
            _genericRepository.Add(session);
            _genericRepository.Save();

            return RedirectToAction("Create");
        }
    }
}