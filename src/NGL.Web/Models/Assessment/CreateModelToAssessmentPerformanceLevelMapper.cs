using NGL.Web.Data.Entities;
using NGL.Web.Data.Expressions;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapper : MapperBase<CreateModel, AssessmentPerformanceLevel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentPerformanceLevelMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, AssessmentPerformanceLevel target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AssessmentReportingMethodTypeId = (int) source.ReportingMethod;

            var query = new GradeLevelTypeDescriptorQuery((int)source.GradeLevel.GetValueOrDefault());

            var assessedGradeLevelDescriptor = _genericRepository.Get(query);
            target.AssessedGradeLevelDescriptorId = assessedGradeLevelDescriptor.GradeLevelDescriptorId;
        }

        public AssessmentPerformanceLevel BuildWithPerformanceLevel(CreateModel createModel, 
            Data.Entities.Assessment assessment,
            PerformanceLevelDescriptorEnum performanceLevelDescriptor)
        {
            var expression = new PerformanceLevelMapperExpression(assessment, performanceLevelDescriptor);
            var assessmentPerformanceLevel = Build(createModel, expression.Expression);

            if (performanceLevelDescriptor == PerformanceLevelDescriptorEnum.Mastery)
                assessmentPerformanceLevel.MinimumScore = createModel.Mastery.ToString();

            else if (performanceLevelDescriptor == PerformanceLevelDescriptorEnum.NearMastery)
                assessmentPerformanceLevel.MinimumScore = createModel.NearMastery.ToString();

            return assessmentPerformanceLevel;
        }
    }

}