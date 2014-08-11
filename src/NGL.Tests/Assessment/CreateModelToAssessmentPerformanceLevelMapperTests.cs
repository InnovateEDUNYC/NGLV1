using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Expressions;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class CreateModelToAssessmentPerformanceLevelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            const PerformanceLevelDescriptorEnum performanceLevelDescriptor = PerformanceLevelDescriptorEnum.Mastery;
            var createModel = new CreateModelBuilder().Build();
            var assessment = new AssessmentBuilder().Build();

            var performanceLevelMapperExpression = new PerformanceLevelMapperExpression(assessment, performanceLevelDescriptor);
            var entity = new CreateModelToAssessmentPerformanceLevelMapper().Build(createModel, performanceLevelMapperExpression.Expression);


            entity.AcademicSubjectDescriptorId.ShouldBe(assessment.AcademicSubjectDescriptorId);
            entity.Version.ShouldBe(assessment.Version);

            entity.AssessmentTitle.ShouldBe(createModel.AssessmentTitle);
            entity.AssessedGradeLevelDescriptorId.ShouldBe((int) createModel.GradeLevel.GetValueOrDefault());
            entity.AssessmentReportingMethodTypeId.ShouldBe((int) createModel.ReportingMethod);
            entity.PerformanceLevelDescriptorId.ShouldBe((int) performanceLevelDescriptor);
        }

    }
}
