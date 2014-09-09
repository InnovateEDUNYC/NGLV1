using System;
using System.Linq;
using System.Linq.Expressions;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class StudentAssessmentsToAssessmentResultModelMapperTests
    {
        private IGenericRepository _genericRepository;

        [Fact]
        public void ShouldMap()
        {
            SetUp();
            var studentAssessment = BuildFirstStudentAssessment();

            var startDate = studentAssessment.Assessment.AdministeredDate.AddDays(-5);
            var endDate = startDate.AddDays(6);
            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper(_genericRepository).Map(new[] {studentAssessment}, startDate, endDate);

            assessmentResultModel.ShouldNotBe(null);
            assessmentResultModel.DateRange.ShouldBe(startDate.ToShortDateString() + " - " + endDate.ToShortDateString());

            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCoreStandard.ShouldBe(studentAssessment.Assessment.AssessmentLearningStandards.First().LearningStandard.Description);
            firstRowModel.SectionCode.ShouldBe(studentAssessment.Assessment.AssessmentSections.First().Section.UniqueSectionCode);
            firstRowModel.AssessmentTitle.ShouldBe(studentAssessment.Assessment.AssessmentTitle);

            firstRowModel.Date.ShouldBe(studentAssessment.AdministrationDate);
            firstRowModel.AssessmentTypeDescription.ShouldBe(studentAssessment.Assessment.AssessmentCategoryType.ShortDescription);
            firstRowModel.Grade.ShouldBe(studentAssessment.StudentAssessmentScoreResults.First().Result);
            
            firstRowModel.Results.ShouldBe(new []{"", "", "", "", "", "Mastery", ""});
        }

        [Fact]
        public void ShouldMapMultipleAssessments()
        {
            SetUp();
            var studentAssessment = BuildFirstStudentAssessment();
            var studentAssessmentTwo = BuildStudentAssessmentTwo();

            var startDate = studentAssessment.AdministrationDate.AddDays(-5);
            var endDate = startDate.AddDays(6);
            var assessmentResultModel = new StudentAssessmentsToAssessmentResultModelMapper(_genericRepository)
                .Map(new[] { studentAssessment, studentAssessmentTwo }, startDate, endDate);
            assessmentResultModel.ShouldNotBe(null);

            var firstRowModel = assessmentResultModel.AssessmentResultRows[0];
            firstRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");
            firstRowModel.Results.Count.ShouldBe(7);
            firstRowModel.Results.ShouldBe(new[] { "", "", "", "", "", "Mastery", "" });
            
            var secondRowModel = assessmentResultModel.AssessmentResultRows[1];
            secondRowModel.CommonCoreStandard.ShouldBe("English - Reading Comprehension");
            secondRowModel.Results.Count.ShouldBe(7);
            secondRowModel.Results.ShouldBe(new[] { "", "", "", "", "", "Not Mastered", "" });
        }

        private void SetUp()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
        }

        private StudentAssessment BuildFirstStudentAssessment()
        {
            var assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            _genericRepository.Get(Arg.Any<Expression<Func<AssessmentCategoryType, bool>>>())
                .Returns(new AssessmentCategoryType { ShortDescription = assessment.AssessmentCategoryType.ShortDescription });


            var section = new SectionBuilder().WithAssessment(assessment).Build(); //To add section to assessment

            assessment.AssessmentSections = new AssessmentBuilder().WithSection(section).Build().AssessmentSections;
            var studentAssessmentScoreResult = new StudentAssessmentScoreResultBuilder().WithResult("95.7").Build();
            var studentAssessment = new StudentAssessmentBuilder().WithAssessment(assessment)
                            .WithStudentAssessmentScoreResult(studentAssessmentScoreResult).Build();
            return studentAssessment;
        }

        private static StudentAssessment BuildStudentAssessmentTwo()
        {
            var assessmentTwo = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();

            new SectionBuilder().WithAssessment(assessmentTwo).Build();  //To add section to assessment
            var studentAssessmentScoreResult = new StudentAssessmentScoreResultBuilder().WithResult("69.5").Build();
            var studentAssessmentTwo = new StudentAssessmentBuilder()
                .WithAssessment(assessmentTwo)
                .WithStudentAssessmentScoreResult(studentAssessmentScoreResult)
                .Build();
            return studentAssessmentTwo;
        }
    }
}
