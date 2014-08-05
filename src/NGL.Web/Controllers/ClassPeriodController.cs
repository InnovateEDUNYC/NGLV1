using System.Collections.Generic;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.ClassPeriod;

namespace NGL.Web.Controllers
{
    public partial class ClassPeriodController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<CreateModel, ClassPeriod> _createModelToClassPeriodMapper;
        private readonly IMapper<ClassPeriod, IndexModel> _classPeriodToIndexModelMapper;

        public ClassPeriodController(IGenericRepository genericRepository, 
            IMapper<CreateModel, ClassPeriod> createModelToClassPeriodMapper, 
            IMapper<ClassPeriod, IndexModel> classPeriodToIndexModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToClassPeriodMapper = createModelToClassPeriodMapper;
            _classPeriodToIndexModelMapper = classPeriodToIndexModelMapper;
        }

        // GET: /ClassPeriod
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            IEnumerable<ClassPeriod> classPeriods = _genericRepository.GetAll<ClassPeriod>();
            var indexModels = new List<IndexModel>();

            foreach (var classPeriod in classPeriods)
            {
                var indexModel = new IndexModel();
                _classPeriodToIndexModelMapper.Map(classPeriod, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }

        // GET: /ClassPeriod/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //POST: /ClassPeriod/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var classPeriod = new ClassPeriod();
            _createModelToClassPeriodMapper.Map(createModel, classPeriod);

            _genericRepository.Add(classPeriod);
            _genericRepository.Save();

            return RedirectToAction("Index");
        }
	}
}