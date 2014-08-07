using System;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
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
            var studentAssessment = BuildFirstStudentAssessment();

            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper().Map(new[] {studentAssessment}, new DateTime(2014, 6, 22), new DateTime(2014, 6, 29));
            assessmentResultModel.ShouldNotBe(null);
            
            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");

            firstRowModel.Results.ShouldBe(new []{"", "", "", "", "", "Mastery", ""});
        }

        private static StudentAssessment BuildFirstStudentAssessment()
        {
            var assessment = new AssessmentBuilder().Build();
            var studentAssessment = new StudentAssessmentBuilder().WithAssessment(assessment).Build();
            return studentAssessment;
        }

        [Fact]
        public void ShouldMapMultipleAssessments()
        {
            var studentAssessment = BuildFirstStudentAssessment();

            var studentAssessmentTwo = BuildStudentAssessmentTwo();

            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper().Map(new[] { studentAssessment, studentAssessmentTwo }, new DateTime(2014, 6, 22), new DateTime(2014, 6, 29));
            assessmentResultModel.ShouldNotBe(null);
            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");
            firstRowModel.Results.Count.ShouldBe(7);
            firstRowModel.Results.ShouldBe(new[] { "", "", "", "", "", "Mastery", "" });
            
            var secondRowModel = assessmentResultModel.AssessmentResultRows[1];
            secondRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");
            secondRowModel.Results.Count.ShouldBe(7);
            secondRowModel.Results.ShouldBe(new[] { "", "Not Mastered", "", "", "", "", "" });
        }

        private static StudentAssessment BuildStudentAssessmentTwo()
        {
            var assessmentTwo = new AssessmentBuilder().Build();
            var studentAssessmentScoreResult = new StudentAssessmentScoreResultBuilder().WithResult("69.5").Build();
            var studentAssessmentTwo = new StudentAssessmentBuilder()
                .WithAssessment(assessmentTwo)
                .WithStudentAssessmentScoreResult(studentAssessmentScoreResult)
                .WithAdministrationDate(new DateTime(2014, 6, 23))
                .Build();
            return studentAssessmentTwo;
        }
    }
}
