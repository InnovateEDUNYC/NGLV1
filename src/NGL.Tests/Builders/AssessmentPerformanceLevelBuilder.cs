using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentPerformanceLevelBuilder
    {
        private string _minimumScore = "85";
        private int _performanceLevelDescriptorId = (int) PerformanceLevelDescriptorEnum.Mastery;

        public AssessmentPerformanceLevel Build()
        {
            return new AssessmentPerformanceLevel
            {
                PerformanceLevelDescriptorId = _performanceLevelDescriptorId,
                MinimumScore = _minimumScore
            };
        }

        public AssessmentPerformanceLevelBuilder WithMinimumScore(string minimumScore)
        {
            _minimumScore = minimumScore;
            return this;
        }

        public AssessmentPerformanceLevelBuilder WithPerformanceLevelDescriptorId(int performanceLevelDescriptorId)
        {
            _performanceLevelDescriptorId = performanceLevelDescriptorId;
            return this;
        }
    }
}