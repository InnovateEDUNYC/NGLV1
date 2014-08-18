using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Location;

namespace NGL.Web.Controllers
{
    public partial class LocationController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<CreateModel, Location> _createModelToLocationMapper;
        private readonly IMapper<Location, IndexModel> _locationToIndexModelMapper;

        public LocationController(IGenericRepository genericRepository, 
            IMapper<CreateModel, Location> createModelToLocationMapper, 
            IMapper<Location, IndexModel> locationToIndexModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToLocationMapper = createModelToLocationMapper;
            _locationToIndexModelMapper = locationToIndexModelMapper;
        }

        // GET: /Location/
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var locations = _genericRepository.GetAll<Location>().ToList();
            var indexModels = new List<IndexModel>();

            foreach (var location in locations)
            {
                var indexModel = new IndexModel();
                 _locationToIndexModelMapper.Map(location, indexModel);
                indexModels.Add(indexModel);
            }

            return View(indexModels);
        }

        // GET: /Location/Create/
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: /Location/Create/
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var location = new Location();
            _createModelToLocationMapper.Map(createModel, location);

            _genericRepository.Add(location);
            _genericRepository.Save();

            return RedirectToAction("Index");
        }
	}
}