using System.Collections.ObjectModel;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapper : IPerformanceLevelMapper
    {
        private Data.Entities.Assessment _assessment;

        public AssessmentPerformanceLevel BuildWithPerformanceLevel(CreateModel createModel,
            Data.Entities.Assessment assessment,
            PerformanceLevelDescriptorEnum performanceLevelDescriptor)
        {
            _assessment = assessment;
            if (assessment.AssessmentPerformanceLevels.IsNullOrEmpty())
                assessment.AssessmentPerformanceLevels = new Collection<AssessmentPerformanceLevel>();

            var assessmentPerformanceLevel = Build();
            MapMinimumScore(createModel, performanceLevelDescriptor, assessmentPerformanceLevel);

            MapPerformanceLevel(createModel, assessmentPerformanceLevel);

            assessment.AssessmentPerformanceLevels.Add(assessmentPerformanceLevel);
            return assessmentPerformanceLevel;
        }

        private AssessmentPerformanceLevel Build()
        {
            var target = new AssessmentPerformanceLevel();
            MapAssessment(target);

            return target;
        }

        private void MapPerformanceLevel(CreateModel source, AssessmentPerformanceLevel target)
        {
            target.AssessmentReportingMethodTypeId = (int) source.ReportingMethod;
        }

        private void MapAssessment(AssessmentPerformanceLevel target)
        {
            target.AssessmentTitle = _assessment.AssessmentTitle;
            target.AssessedGradeLevelDescriptorId = _assessment.AssessedGradeLevelDescriptorId;
            target.AcademicSubjectDescriptorId = _assessment.AcademicSubjectDescriptorId;
            target.Version = _assessment.Version;
        }

        private void MapMinimumScore(CreateModel createModel, PerformanceLevelDescriptorEnum performanceLevelDescriptor,
            AssessmentPerformanceLevel assessmentPerformanceLevel)
        {
            assessmentPerformanceLevel.PerformanceLevelDescriptorId = (int) performanceLevelDescriptor;
            switch (performanceLevelDescriptor)
            {
                case PerformanceLevelDescriptorEnum.Mastery:
                    assessmentPerformanceLevel.MinimumScore = createModel.Mastery.ToString();
                    break;
                case PerformanceLevelDescriptorEnum.NearMastery:
                    assessmentPerformanceLevel.MinimumScore = createModel.NearMastery.ToString();
                    break;
            }
        }
    }
}