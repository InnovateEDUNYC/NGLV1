using NGL.Tests.Builders;
using NGL.Web.Models.Assessment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class LearningStandardToCommonCoreStandardListItemModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var entity = new LearningStandardBuilder().Build();
            var model = new LearningStandardToCommonCoreStandardListItemModelMapper().Build(entity);

            model.LearningStandardId.ShouldBe(entity.LearningStandardId);
            model.Description.ShouldBe(entity.Description);
        }
    }
}
