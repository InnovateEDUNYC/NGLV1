using System;
using System.Collections.Generic;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentBuilder
    {
        private const int AssessmentIdentity = 1;
        private const string AssessmentTitle = "My Assessment";
        private const int AcademicSubjectDescriptorId = 1;
        private const int AssessedGradeLevelDescriptorId = 1;
        private const int AssessmentCategoryTypeId = (int) AssessmentCategoryTypeEnum.Classquiz;
        private const int Version = 1;
        private readonly DateTime _administeredDate = new DateTime(2014, 6, 22);
        private ICollection<AssessmentSection> _assessmentSections = new List<AssessmentSection>();
        private IList<AssessmentLearningStandard> _assessmentLearningStandards;
        private IList<AssessmentPerformanceLevel> _assessmentPerformanceLevels;

        public Web.Data.Entities.Assessment Build()
        {
            return new Web.Data.Entities.Assessment
            {
                AssessmentLearningStandards = _assessmentLearningStandards,
                AssessmentPerformanceLevels = _assessmentPerformanceLevels,
                AssessmentIdentity = AssessmentIdentity,
                AssessmentTitle = AssessmentTitle,
                AcademicSubjectDescriptorId = AcademicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = AssessedGradeLevelDescriptorId,
                Version = Version,
                AssessmentSections = _assessmentSections,
                AdministeredDate = _administeredDate,
                AssessmentCategoryTypeId = AssessmentCategoryTypeId,
                AssessmentCategoryType = new AssessmentCategoryType
                {
                    AssessmentCategoryTypeId = AssessmentCategoryTypeId,
                    ShortDescription = AssessmentCategoryTypeEnum.Classquiz.Humanize()
                }
            };
        }

        public AssessmentBuilder WithSection(Web.Data.Entities.Section section)
        {
            _assessmentSections = new List<AssessmentSection>
            {
                new AssessmentSection
                {
                    Section = section
                }
            };
            return this;
        }

        public AssessmentBuilder WithAssessmentLearningStandards()
        {
            _assessmentLearningStandards = new[] { new AssessmentLearningStandardBuilder().Build() };
            return this;
        }

        public AssessmentBuilder WithAssessmentPerformanceLevels()
        {
            _assessmentPerformanceLevels = new[]
            {
                new AssessmentPerformanceLevelBuilder().Build(),
                new AssessmentPerformanceLevelBuilder()
                    .WithPerformanceLevelDescriptorId((int) PerformanceLevelDescriptorEnum.NearMastery)
                    .WithMinimumScore("70").Build()
            };
            return this;
        }
    }
}
