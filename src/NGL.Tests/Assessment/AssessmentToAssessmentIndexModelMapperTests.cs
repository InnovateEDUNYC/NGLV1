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

            indexModel.AssessmentTitle.ShouldBe("My Assessment");
            indexModel.SessionName.ShouldBe("Fall 2014");
            indexModel.SectionName.ShouldBe("CHEM2090 - 200");
            indexModel.CCSS.ShouldBe("English - Reading Comprehension");
            indexModel.Date.ShouldBe("9/9/2014");
            indexModel.id.ShouldBe(1);
        }
    }
}
