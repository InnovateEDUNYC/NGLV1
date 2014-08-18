using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class AssessmentToAssessmentIndexModelMapperTests
    {
        [Fact]
        public void ShouldMapAssessmentToIndexModelMapper()
        {
            var mapper = new AssessmentToAssessmentIndexModelMapper();
            Web.Data.Entities.Assessment assessment = new AssessmentBuilder()
                .WithAssessmentLearningStandards()
                .WithAssessmentPerformanceLevels()
                .Build();
            var section = new SectionBuilder().WithAssessment(assessment).Build();
            
            var indexModel = mapper.Build(assessment);

            indexModel.AssessmentTitle.ShouldBe(assessment.AssessmentTitle);
            indexModel.SessionName.ShouldBe(section.Session.SessionName);
            indexModel.SectionName.ShouldBe(section.UniqueSectionCode);
            indexModel.CCSS.ShouldBe(assessment.AssessmentLearningStandards.First().LearningStandard.Description);
            indexModel.Date.ShouldBe(assessment.AdministeredDate.ToShortDateString());
            indexModel.id.ShouldBe(1);
        }
    }
}
