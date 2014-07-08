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
        private readonly IMapper<SessionCreateModel, Session> _sessionModelToSessionMapper;
        private readonly IMapper<Session, SessionIndexModel> _sessionToSessionIndexModelMapper;

        public SessionController(IGenericRepository genericRepository, 
            IMapper<SessionCreateModel, Session> sessionModelToSessionMapper, 
            IMapper<Session, SessionIndexModel> sessionToSessionIndexModelMapper)
        {
            _genericRepository = genericRepository;
            _sessionModelToSessionMapper = sessionModelToSessionMapper;
            _sessionToSessionIndexModelMapper = sessionToSessionIndexModelMapper;
        }

        public virtual ActionResult Index()
        {
            IEnumerable<Session> sessions = _genericRepository.GetAll<Session>();
            var sessionIndexModels = new List<SessionIndexModel>();

            foreach (var session in sessions)
            {
                var sessionIndexModel = new SessionIndexModel();
                _sessionToSessionIndexModelMapper.Map(session, sessionIndexModel);
                sessionIndexModels.Add(sessionIndexModel);
            }
            return View(sessionIndexModels);
        }

        // GET: Session
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(SessionCreateModel sessionCreateModel)
        {
            if (!ModelState.IsValid)
                return View(sessionCreateModel);

            var session = new Session();
            _sessionModelToSessionMapper.Map(sessionCreateModel, session);
            
            _genericRepository.Add(session);
            _genericRepository.Save();

            return RedirectToAction("Index");
        }
    }
}