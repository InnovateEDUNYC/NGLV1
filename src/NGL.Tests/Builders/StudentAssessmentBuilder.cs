using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentAssessmentBuilder
    {
        private const int StudentUSI = 123;
        private string _assessmentTitle = "English Reading";
        private int _academicSubjectDescriptorId = (int) AcademicSubjectDescriptorEnum.EnglishLanguageArts;
        private int _assessedGradeLevelDescriptorId = (int) GradeLevelDescriptorEnum._5thGrade;
        private int _version = 0;
        private DateTime _administrationDate = new DateTime(2014, 6, 27);
        private Web.Data.Entities.Assessment _assessment = null;
        private IList<StudentAssessmentScoreResult> _studentAssessmentScoreResults = new[] { new StudentAssessmentScoreResultBuilder().Build() };
        private Web.Data.Entities.Student _student;

        public StudentAssessment Build()
        {
            return new StudentAssessment
            {
                StudentUSI = StudentUSI,
                AssessmentTitle = _assessmentTitle,
                AcademicSubjectDescriptorId = _academicSubjectDescriptorId,
                AssessedGradeLevelDescriptorId = _assessedGradeLevelDescriptorId,
                Version = _version,
                AdministrationDate = _administrationDate,
                Assessment = _assessment,
                StudentAssessmentScoreResults = _studentAssessmentScoreResults,
                Student = _student
            };
        }

        public StudentAssessmentBuilder WithAssessment(Web.Data.Entities.Assessment assessment)
        {
            _assessment = assessment;
            _administrationDate = assessment.AdministeredDate;
            _assessmentTitle = assessment.AssessmentTitle;
            _academicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
            _assessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
            _version = assessment.Version;
            return this;
        }

        public StudentAssessmentBuilder WithStudentAssessmentScoreResult(StudentAssessmentScoreResult studentAssessmentScoreResult)
        {
            _studentAssessmentScoreResults = new[] {studentAssessmentScoreResult};
            return this;
        }

        public StudentAssessmentBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _student = student;
            return this;
        }
    }
}