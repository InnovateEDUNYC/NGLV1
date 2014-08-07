using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentAssessmentBuilder
    {
        private const int StudentUSI = 123;
        private const string AssessmentTitle = "English Reading";
        private const int AcademicSubjectDescriptorId = (int) AcademicSubjectDescriptorEnum.EnglishLanguageArts;
        private const int AssessedGradeLevelDescriptorId = (int) GradeLevelDescriptorEnum._5thGrade;
        private const int Version = 1;
        private readonly DateTime _administrationDate = new DateTime(2014, 6, 27);
        private Web.Data.Entities.Assessment _assessment = null;
        private readonly IList<StudentAssessmentScoreResult> _studentAssessmentScoreResults = new[] { new StudentAssessmentScoreResultBuilder().Build() }; 

        public StudentAssessment Build()
        {
            return new StudentAssessment
            {
                StudentUSI = StudentUSI,
                AssessmentTitle = AssessmentTitle,
                AcademicSubjectDescriptorId = AcademicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = AssessedGradeLevelDescriptorId,
                Version = Version,
                AdministrationDate = _administrationDate,
                Assessment = _assessment,
                StudentAssessmentScoreResults = _studentAssessmentScoreResults
            };
        }

        public StudentAssessmentBuilder WithAssessment(Web.Data.Entities.Assessment assessment)
        {
            _assessment = assessment;
            return this;
        }
    }
}