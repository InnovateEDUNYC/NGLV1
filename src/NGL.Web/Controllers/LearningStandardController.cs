using System;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Controllers
{
    public partial class LearningStandardController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ILearningStandardRepository _learningStandardRepository;
        private readonly IMapper<LearningStandard, CommonCoreStandardListItemModel> _learningStandardToCommonCoreStandardListItemModelMapper;

        public LearningStandardController(IGenericRepository genericRepository, IMapper<LearningStandard, CommonCoreStandardListItemModel> learningStandardToCommonCoreStandardListItemModelMapper, ILearningStandardRepository learningStandardRepository)
        {
            _genericRepository = genericRepository;
            _learningStandardToCommonCoreStandardListItemModelMapper = learningStandardToCommonCoreStandardListItemModelMapper;
            _learningStandardRepository = learningStandardRepository;
        }

        [HttpPost]
        public virtual JsonResult GetCommonCoreStandards(string gradeLevelTypeEnum)
        {
            var gradeLevelType = Enum.Parse(typeof (GradeLevelTypeEnum), gradeLevelTypeEnum);
            var commonCoreStandards = _learningStandardRepository.GetCommonCoreStandards((int) gradeLevelType);

            return Json(commonCoreStandards, JsonRequestBehavior.AllowGet);
        }

	}
}