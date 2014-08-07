using System.Collections.Generic;
using NGL.Tests.Assessment;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentBuilder
    {
        private readonly IList<AssessmentLearningStandard> _assessmentLearningStandards = new[] {new AssessmentLearningStandardBuilder().Build()};

        private readonly IList<AssessmentPerformanceLevel> _assessmentPerformanceLevels = new[]
        {
            new AssessmentPerformanceLevelBuilder().Build(),
            new AssessmentPerformanceLevelBuilder()
                .WithPerformanceLevelDescriptorId((int) PerformanceLevelDescriptorEnum.NearMastery)
                .WithMinimumScore("70").Build()
        };

        public Web.Data.Entities.Assessment Build()
        {
            return new Web.Data.Entities.Assessment
            {
                AssessmentLearningStandards = _assessmentLearningStandards,
                AssessmentPerformanceLevels = _assessmentPerformanceLevels
            };
        }
    }
}