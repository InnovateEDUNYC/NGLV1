using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Controllers
{
    public class LearningStandardController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<LearningStandard, CommonCoreStandardListItemModel> _learningStandardToCommonCoreStandardListItemModelMapper;

        public LearningStandardController(IGenericRepository genericRepository, IMapper<LearningStandard, CommonCoreStandardListItemModel> learningStandardToCommonCoreStandardListItemModelMapper)
        {
            _genericRepository = genericRepository;
            _learningStandardToCommonCoreStandardListItemModelMapper = learningStandardToCommonCoreStandardListItemModelMapper;
        }

        [HttpPost]
        public virtual JsonResult GetLearningStandards()
        {
            var learningStandards = _genericRepository.GetAll<LearningStandard>();

//            return Json(Models, JsonRequestBehavior.AllowGet);
            return null;
        }

	}
}