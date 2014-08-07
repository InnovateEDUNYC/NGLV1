using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentMapperTests
    {
        [Fact]
        public void ShouldMapEnterResultsStudentModelToStudentAssessmentMapper()
        {
            var mapper = new EnterResultsStudentModelToStudentAssessmentMapper();
            var model = new EnterResultsStudentModel();
            var entity = new StudentAssessment();
            var assessment = new Web.Data.Entities.Assessment();

            mapper.Map(model, entity, 
                a =>
                    {
                        a.AssessmentTitle = assessment.AssessmentTitle;
                        a.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                        a.AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
                        a.Version = assessment.Version;
                        a.AdministrationDate = assessment.AdministeredDate;
                    });

            entity.StudentUSI.ShouldBe(model.StudentUsi);
            entity.AssessmentTitle.ShouldBe(assessment.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(assessment.AssessedGradeLevelDescriptorId);
            entity.Version.ShouldBe(assessment.Version);
            entity.AdministrationDate.ShouldBe(assessment.AdministeredDate);
        }
    }
}
