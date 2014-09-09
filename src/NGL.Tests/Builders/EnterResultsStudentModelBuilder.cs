using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Builders
{
    class EnterResultsStudentModelBuilder
    {
        private const int StudentUsi = 123;
        private readonly DateTime _administrationDate = new DateTime(2014, 8, 8);
        private readonly decimal? _assessmentResult = 80.4m;
        private const string Name = "Jenny";
        private readonly StudentAssessment _studentAssessment = new StudentAssessment();
        private const string AssessmentTitle = "My assessment";
        private const int AcademicSubjectDescriptorId = 1;
        private const int AssessedGradeLevelDescriptorId = 1;
        private const int Version = 1;

        public EnterResultsStudentModel Build()
        {
            _studentAssessment.AssessmentTitle = AssessmentTitle;
            _studentAssessment.AcademicSubjectDescriptorId = AcademicSubjectDescriptorId;
            _studentAssessment.AssessedGradeLevelDescriptorId = AssessedGradeLevelDescriptorId;
            _studentAssessment.Version = Version;
            _studentAssessment.AdministrationDate = _administrationDate;

            return new EnterResultsStudentModel
            {
                StudentUsi = StudentUsi,
                Name = Name,
                AssessmentResult = _assessmentResult
            };
        }
    }
}
