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

            var startDate = new DateTime(2014, 6, 22);
            var endDate = new DateTime(2014, 6, 28);
            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper().Map(new[] {studentAssessment}, startDate, endDate);

            assessmentResultModel.ShouldNotBe(null);
            assessmentResultModel.DateRange.ShouldBe("6/22/2014 - 6/28/2014");

            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");
            firstRowModel.SectionCode.ShouldBe("CHEM2090 - 200");

            firstRowModel.Results.ShouldBe(new []{"", "", "", "", "", "Mastery", ""});
        }

        [Fact]
        public void ShouldMapMultipleAssessments()
        {
            var studentAssessment = BuildFirstStudentAssessment();
            var studentAssessmentTwo = BuildStudentAssessmentTwo();

            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper().Map(new[] { studentAssessment, studentAssessmentTwo }, new DateTime(2014, 6, 22), new DateTime(2014, 6, 28));
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

        private static StudentAssessment BuildFirstStudentAssessment()
        {
            var assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            var section = new SectionBuilder().WithAssessment(assessment).Build();
            var studentAssessment = new StudentAssessmentBuilder().WithAssessment(assessment).Build();
            return studentAssessment;
        }

        private static StudentAssessment BuildStudentAssessmentTwo()
        {
            var assessmentTwo = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            var section = new SectionBuilder().WithAssessment(assessmentTwo).Build();
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
