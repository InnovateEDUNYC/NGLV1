using System;
using System.Collections.Generic;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentBuilder
    {
        private const int _assessmentIdentity = 1;
        private const string _assessmentTitle = "My Assessment";
        private const int _academicSubjectDescriptorId = 1;
        private const int _assessedGradeLevelDescriptorId = 1;
        private const int _assessmentCategoryTypeId = (int) AssessmentCategoryTypeEnum.Classquiz;
        private const int _version = 1;
        private DateTime _administeredDate = new DateTime(2014, 6, 22);
        private ICollection<AssessmentSection> _assessmentSections = new List<AssessmentSection>();
        private IList<AssessmentLearningStandard> _assessmentLearningStandards;
        private IList<AssessmentPerformanceLevel> _assessmentPerformanceLevels;

        public Web.Data.Entities.Assessment Build()
        {
            return new Web.Data.Entities.Assessment
            {
                AssessmentLearningStandards = _assessmentLearningStandards,
                AssessmentPerformanceLevels = _assessmentPerformanceLevels,
                AssessmentIdentity = _assessmentIdentity,
                AssessmentTitle = _assessmentTitle,
                AcademicSubjectDescriptorId = _academicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = _assessedGradeLevelDescriptorId,
                Version = _version,
                AssessmentSections = _assessmentSections,
                AdministeredDate = _administeredDate,
                AssessmentCategoryTypeId = _assessmentCategoryTypeId,
                AssessmentCategoryType = new AssessmentCategoryType
                {
                    AssessmentCategoryTypeId = _assessmentCategoryTypeId,
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
