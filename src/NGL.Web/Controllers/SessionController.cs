using System.Collections.Generic;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Session;

namespace NGL.Web.Controllers
{
    public partial class SessionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<SessionModel, Session> _sessionModelToSessionMapper;
        private readonly IMapper<Session, SessionModel> _sessionToSessionModelMapper;

        public SessionController(IGenericRepository genericRepository, 
            IMapper<SessionModel, Session> sessionModelToSessionMapper, 
            IMapper<Session, SessionModel> sessionToSessionModelMapper)
        {
            _genericRepository = genericRepository;
            _sessionModelToSessionMapper = sessionModelToSessionMapper;
            _sessionToSessionModelMapper = sessionToSessionModelMapper;
        }

        public virtual ActionResult Index()
        {
            IEnumerable<Session> sessions = _genericRepository.GetAll<Session>();
            var sessionModels = new List<SessionModel>();

            foreach (var session in sessions)
            {
                var sessionModel = new SessionModel();
                _sessionToSessionModelMapper.Map(session, sessionModel);
                sessionModels.Add(sessionModel);
            }
            return View(sessionModels);
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
            _sessionModelToSessionMapper.Map(sessionModel, session);
            
            _genericRepository.Add(session);
            _genericRepository.Save();

            return RedirectToAction("Index");
        }
    }
}