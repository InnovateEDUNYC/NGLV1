using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Controllers
{
    public partial class AssessmentController : Controller
    {
        private readonly IMapper<CreateModel, Assessment> _createModelToAssessmentMapper;
        private readonly IGenericRepository _genericRepository;

        public AssessmentController(IMapper<CreateModel, Assessment> createModelToAssessmentMapper, IGenericRepository genericRepository)
        {
            _createModelToAssessmentMapper = createModelToAssessmentMapper;
            _genericRepository = genericRepository;
        }

        //
        // GET: /Assessment/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Assessment/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var assessment = _createModelToAssessmentMapper.Build(createModel);
            _genericRepository.Add(assessment);
            _genericRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }

    }
}