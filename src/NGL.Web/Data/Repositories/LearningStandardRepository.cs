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
        private readonly IEnumerable<LearningStandard> _commonCoreStandards;

        public LearningStandardRepository(INglDbContext dbContext, IMapper<LearningStandard, CommonCoreStandardListItemModel> learningStandardToCommonCoreStandardListItemModelMapper) : base(dbContext)
        {
            _learningStandardToCommonCoreStandardListItemModelMapper = learningStandardToCommonCoreStandardListItemModelMapper;
            _commonCoreStandards = DbContext.Set<LearningStandard>().ToEnumerable();
        }


        public List<CommonCoreStandardListItemModel> GetAllCommonCoreAnchorStandards()
        {
            var commonCoreStandards = _commonCoreStandards.Where(
                ls => ls.GradeLevelDescriptorId == UngradedGradeLevelDescriptorId);

            return BuildListItemModels(commonCoreStandards);
        }


        public List<CommonCoreStandardListItemModel> FilterCommonCoreStandards(int gradeLevelTypeId, int academicSubjectDescriptorId)
        {
            var commonCoreStandards = SelectByGradeLevelAndAcademicSubject(
                gradeLevelTypeId, academicSubjectDescriptorId);
            commonCoreStandards = commonCoreStandards.Union(_commonCoreStandards.Where(
                ls => ls.GradeLevelDescriptorId == UngradedGradeLevelDescriptorId));
            return BuildListItemModels(commonCoreStandards);
        }

        private IEnumerable<LearningStandard> SelectByGradeLevelAndAcademicSubject(int gradeLevelTypeId, int academicSubjectDescriptorId)
        {
            var gradeLevelDescriptorId = GetGradeLevelDescriptorFromGradeType(gradeLevelTypeId);

            var commonCoreStandards = _commonCoreStandards.Where(
                ls => ls.GradeLevelDescriptorId == gradeLevelDescriptorId &&
                        ls.AcademicSubjectDescriptorId == academicSubjectDescriptorId);

            return commonCoreStandards;
        }

        private int GetGradeLevelDescriptorFromGradeType(int gradeLevelTypeId)
        {
            var gradeLevelDescriptorQueryable =
                DbContext.Set<GradeLevelDescriptor>().Where(gld => gld.GradeLevelTypeId == gradeLevelTypeId);
            var gradeLevelDescriptor = gradeLevelDescriptorQueryable.Single();

            return gradeLevelDescriptor.GradeLevelDescriptorId;
        }

        private List<CommonCoreStandardListItemModel> BuildListItemModels(IEnumerable<LearningStandard> commonCoreStandards)
        {
            return commonCoreStandards.Select(ccss => _learningStandardToCommonCoreStandardListItemModelMapper.Build(ccss)).OrderBy(c => c.Description).ToList();
        }
    }
}