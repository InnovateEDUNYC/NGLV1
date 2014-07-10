using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models;
using NGL.Web.Models.Session;

namespace NGL.Web.Controllers
{
    public partial class SessionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<CreateModel, Session> _createModelToEntityMapper;
        private readonly IMapper<Session, IndexModel> _entityToIndexModelMapper;

        public SessionController(IGenericRepository genericRepository, 
            IMapper<CreateModel, Session> createModelToEntityMapper, 
            IMapper<Session, IndexModel> entityToIndexModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToEntityMapper = createModelToEntityMapper;
            _entityToIndexModelMapper = entityToIndexModelMapper;
        }

        public virtual ActionResult Index()
        {
            IEnumerable<Session> sessions = _genericRepository.GetAll<Session>();
            var indexModels = new List<IndexModel>();

            foreach (var session in sessions)
            {
                var indexModel = new IndexModel();
                _entityToIndexModelMapper.Map(session, indexModel);
                indexModels.Add(indexModel);
            }
            return View(indexModels);
        }

        // GET: Session
        public virtual ActionResult Create()
        {

            return View(new CreateModel());
        }

        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            //var sessionByTermTypeAndSchoolYearQuery = new SessionByTermTypeAndSchoolYearQuery(
            //    (int) createModel.Term,
            //    (short) createModel.SchoolYear);

            //CheckIfExists(createModel, sessionByTermTypeAndSchoolYearQuery);

            if (!ModelState.IsValid)
                return View(createModel);


            var session = new Session();
            _createModelToEntityMapper.Map(createModel, session);
            _genericRepository.Add(session);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }

        //private void CheckIfExists(CreateModel createModel, SessionByTermTypeAndSchoolYearQuery query)
        //{
        //    if (createModel.Term != null)
        //    {
        //        ValidateExistence(createModel, query);
        //    }
        //}

        //private void ValidateExistence<T>(CreateModel createModel, IQuery<T> query) where T : class
        //{
        //    var existingEntity = _genericRepository.Get(query);

        //    if (existingEntity != null)
        //    {
        //        PutModelErrors(createModel);
        //    }
        //}

        //private void PutModelErrors(IFormModel formModel)
        //{
        //    foreach (var error in formModel.GetErrors())
        //    {
        //        ModelState.AddModelError(error.Key, error.Value);
        //    }
        //}
    }
}