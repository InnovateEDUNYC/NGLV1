using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Section;
using CreateModel = NGL.Web.Models.Section.CreateModel;
using IndexModel = NGL.Web.Models.Section.IndexModel;

namespace NGL.Web.Controllers
{
    public partial class SectionController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<Section, IndexModel> _sectionToIndexModelMapper;
        private readonly IMapper<ClassPeriod, ClassPeriodNameModel> _classPeriodToClassPeriodNameModelMapper;
        private readonly IMapper<Location, ClassRoomModel> _locationToClassRoomModelMapper;

        public SectionController(IGenericRepository genericRepository, 
            IMapper<Section, IndexModel> sectionToIndexModelMapper, 
            IMapper<ClassPeriod, ClassPeriodNameModel> classPeriodToClassPeriodNameModelMapper, 
            IMapper<Location, ClassRoomModel> locationToClassRoomModelMapper)
        {
            _genericRepository = genericRepository;
            _sectionToIndexModelMapper = sectionToIndexModelMapper;
            _classPeriodToClassPeriodNameModelMapper = classPeriodToClassPeriodNameModelMapper;
            _locationToClassRoomModelMapper = locationToClassRoomModelMapper;
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
            var classPeriodModels = GetClassPeriodNameModels();
            var classRoomModels = GetClassRoomModels();

            var createModel = CreateModel.CreateNewWith(classPeriodModels, classRoomModels);
            return View(createModel);
        }

        // POST: /Section/Create

        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                createModel.ClassPeriodNames = GetClassPeriodNameModels();
                createModel.ClassRooms = GetClassRoomModels();
                return View(createModel);
            }


            return RedirectToAction(Actions.Index());
        }

        private List<ClassPeriodNameModel> GetClassPeriodNameModels()
        {
            var classPeriods = _genericRepository.GetAll<ClassPeriod>();
            var classPeriodModels = classPeriods.Select(classPeriod =>
                _classPeriodToClassPeriodNameModelMapper.Build(classPeriod)).ToList();
            return classPeriodModels;
        }

        private List<ClassRoomModel> GetClassRoomModels()
        {
            var locations = _genericRepository.GetAll<Location>();
            return locations.Select(location => _locationToClassRoomModelMapper.Build(location)).ToList();
        }
    }
}