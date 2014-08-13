using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Builders
{
    class EnterResultsStudentModelBuilder
    {
        private int _studentUsi = 123;
        private DateTime _administrationDate = new DateTime(2014, 8, 8);
        private decimal? _assessmentResult = 80.4m;
        private string _name = "Jenny";
        private StudentAssessment _studentAssessment = new StudentAssessment();
        private string _assessmentTitle = "My assessment";
        private int _academicSubjectDescriptorId = 1;
        private int _assessedGradeLevelDescriptorId = 1;
        private int _version = 1;

        public EnterResultsStudentModel Build()
        {
            _studentAssessment.AssessmentTitle = _assessmentTitle;
            _studentAssessment.AcademicSubjectDescriptorId = _academicSubjectDescriptorId;
            _studentAssessment.AssessedGradeLevelDescriptorId = _assessedGradeLevelDescriptorId;
            _studentAssessment.Version = _version;
            _studentAssessment.AdministrationDate = _administrationDate;

            return new EnterResultsStudentModel
            {
                StudentUsi = _studentUsi,
                Name = _name,
                AssessmentResult = _assessmentResult
            };
        }
    }
}
