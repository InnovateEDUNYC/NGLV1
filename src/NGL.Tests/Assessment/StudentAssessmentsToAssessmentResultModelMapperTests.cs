using System;
using NGL.Tests.Builders;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class StudentAssessmentsToAssessmentResultModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var assessment = new AssessmentBuilder().Build();
            var studentAssessment = new StudentAssessmentBuilder().WithAssessment(assessment).Build();

            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper().Map(new[] {studentAssessment}, new DateTime(2014, 6, 22), new DateTime(2014, 6, 29));
            assessmentResultModel.ShouldNotBe(null);
            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCodeStandard.ShouldBe("English - Reading Comprehension");

            firstRowModel.Results.Count.ShouldBe(7);
            firstRowModel.Results.ShouldBe(new []{"", "", "", "", "", "Mastery", ""});
        }
    }
}
