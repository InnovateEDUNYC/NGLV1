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
        public virtual JsonResult GetCommonCoreStandards(string gradeLevelTypeEnum, string academicSubjectDescriptorEnum)
        {
            if (EitherIsNullOrWhitespace(gradeLevelTypeEnum, academicSubjectDescriptorEnum))
                return Json(new {BadInput = true}, JsonRequestBehavior.AllowGet);

            var gradeLevelType = Enum.Parse(typeof (GradeLevelTypeEnum), gradeLevelTypeEnum);
            var academicSubjectDescriptor = Enum.Parse(typeof (AcademicSubjectDescriptorEnum),
                academicSubjectDescriptorEnum);

            var commonCoreStandards = _learningStandardRepository.FilterCommonCoreStandards((int) gradeLevelType, (int) academicSubjectDescriptor);

            return Json(commonCoreStandards, JsonRequestBehavior.AllowGet);
        }

        private static bool EitherIsNullOrWhitespace(string gradeLevelTypeEnum, string academicSubjectDescriptorEnum)
        {
            return String.IsNullOrWhiteSpace(gradeLevelTypeEnum) ||
                   String.IsNullOrWhiteSpace(academicSubjectDescriptorEnum);
        }
    }
}