using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentLearningStandardMapper : MapperBase<CreateModel, AssessmentLearningStandard>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentLearningStandardMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, AssessmentLearningStandard target)
        {
            target.AssessmentTitle = source.AssessmentTitle;

            var query = new GradeLevelTypeDescriptorQuery((int)source.GradeLevel.GetValueOrDefault());

            var assessedGradeLevelDescriptor = _genericRepository.Get(query);
            target.AssessedGradeLevelDescriptorId = assessedGradeLevelDescriptor.GradeLevelDescriptorId;

            target.LearningStandardId = source.CommonCoreStandard;
        }
    }
}