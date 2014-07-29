using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Section;

namespace NGL.Web.Controllers
{
    public partial class SectionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<Section, IndexModel> _sectionToIndexModelMapper;

        public SectionController(IGenericRepository genericRepository, IMapper<Section, IndexModel> sectionToIndexModelMapper)
        {
            _genericRepository = genericRepository;
            _sectionToIndexModelMapper = sectionToIndexModelMapper;
        }

        // GET: /Section
        public virtual ActionResult Index()
        {
            IEnumerable<Section> sections = _genericRepository.GetAll<Section>();
            var indexModels = new List<IndexModel>();
            foreach (var section in sections)
            {
                var indexModel = new IndexModel();
                _sectionToIndexModelMapper.Map(section, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }
        //
        // GET: /Section/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: /Section/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            return View();
        }
    }
}