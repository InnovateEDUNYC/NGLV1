using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentLearningStandardBuilder
    {
        private readonly LearningStandard _learningStandard = new LearningStandardBuilder().Build();

        public AssessmentLearningStandard Build()
        {
            return new AssessmentLearningStandard
            {
                LearningStandard = _learningStandard
            };
        }
    }
}