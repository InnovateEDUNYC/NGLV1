using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class AssessmentBuilder
    {
        private const int _assessmentIdentity = 1;
        private const string _assessmentTitle = "My Assessment";
        private const int _academicSubjectDescriptorId = 1;
        private const int _assessedGradeLevelDescriptorId = 1;
        private const int _version = 1;
        private DateTime _administeredDate = new DateTime(2014, 9, 9);
        private readonly ICollection<AssessmentSection> _assessmentSections = new List<AssessmentSection>();
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
            };
        }

        public AssessmentBuilder WithAdministeredDate(DateTime administeredDate)
        {
            _administeredDate = administeredDate;
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
