using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class EnterResultsStudentModelToStudentAssessmentMapperTests
    {
        [Fact]
        public void ShouldMapEnterResultsStudentModelToStudentAssessment()
        {
            var enterResultsStudentModelToStudentAssessmentMapper = new EnterResultsStudentModelToStudentAssessmentMapper(new EnterResultsStudentModelToStudentAssessmentScoreResultMapper());
            var mapper = enterResultsStudentModelToStudentAssessmentMapper;
            var model = new EnterResultsStudentModel();
            var assessment = new Web.Data.Entities.Assessment();

            var entity = mapper.Build(model, assessment);

            entity.StudentUSI.ShouldBe(model.StudentUsi);
            entity.AssessmentTitle.ShouldBe(assessment.AssessmentTitle);
            entity.AcademicSubjectDescriptorId.ShouldBe(assessment.AcademicSubjectDescriptorId);
            entity.AssessedGradeLevelDescriptorId.ShouldBe(assessment.AssessedGradeLevelDescriptorId);
            entity.Version.ShouldBe(assessment.Version);
            entity.AdministrationDate.ShouldBe(assessment.AdministeredDate);
        }
    }
}
