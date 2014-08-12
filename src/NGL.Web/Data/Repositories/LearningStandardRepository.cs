using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using Ninject.Infrastructure.Language;

namespace NGL.Web.Data.Repositories
{
    public class LearningStandardRepository : RepositoryBase, ILearningStandardRepository
    {
        private const int UngradedGradeLevelDescriptorId = 139;
        private readonly IMapper<LearningStandard, CommonCoreStandardListItemModel> _learningStandardToCommonCoreStandardListItemModelMapper;

        public LearningStandardRepository(INglDbContext dbContext, IMapper<LearningStandard, CommonCoreStandardListItemModel> learningStandardToCommonCoreStandardListItemModelMapper) : base(dbContext)
        {
            _learningStandardToCommonCoreStandardListItemModelMapper = learningStandardToCommonCoreStandardListItemModelMapper;
        }
        public List<CommonCoreStandardListItemModel> GetCommonCoreStandards()
        {
            return GetCommonCoreStandards(gradeLevelTypeId:null);
        }

        public List<CommonCoreStandardListItemModel> GetCommonCoreStandards(int? gradeLevelTypeId)
        {
            var commonCoreStandards = DbContext.Set<LearningStandard>().ToEnumerable();

            if (gradeLevelTypeId == null)
            {
                commonCoreStandards = GetCommonCoreStandardsWithoutGrade(commonCoreStandards);
            }
            else
                commonCoreStandards = GetCommonCoreStandardsWithGrade((int) gradeLevelTypeId, commonCoreStandards);

            return BuildCommonCoreStandardListItemModels(commonCoreStandards);
        }

        private static IEnumerable<LearningStandard> GetCommonCoreStandardsWithoutGrade(IEnumerable<LearningStandard> commonCoreStandards)
        {
            commonCoreStandards = commonCoreStandards.Where(ls => ls.GradeLevelDescriptorId == UngradedGradeLevelDescriptorId);
            return commonCoreStandards;
        }

        private IEnumerable<LearningStandard> GetCommonCoreStandardsWithGrade(int gradeLevelTypeId, IEnumerable<LearningStandard> commonCoreStandards)
        {
            var gradeLevelDescriptorId = GetGradeLevelDescriptorFromGradeType(gradeLevelTypeId);

            commonCoreStandards =
                commonCoreStandards.Where(ls => ls.GradeLevelDescriptorId == gradeLevelDescriptorId)
                .Union(GetCommonCoreStandardsWithoutGrade(commonCoreStandards));

            return commonCoreStandards;
        }

        private int GetGradeLevelDescriptorFromGradeType(int gradeLevelTypeId)
        {
            var gradeLevelDescriptorQueryable =
                DbContext.Set<GradeLevelDescriptor>().Where(gld => gld.GradeLevelTypeId == gradeLevelTypeId);
            var gradeLevelDescriptor = gradeLevelDescriptorQueryable.Single();
            return gradeLevelDescriptor.GradeLevelDescriptorId;
        }

        private List<CommonCoreStandardListItemModel> BuildCommonCoreStandardListItemModels(IEnumerable<LearningStandard> commonCoreStandards)
        {
            return commonCoreStandards.Select(ccss => _learningStandardToCommonCoreStandardListItemModelMapper.Build(ccss)).ToList();
        }
    }
}