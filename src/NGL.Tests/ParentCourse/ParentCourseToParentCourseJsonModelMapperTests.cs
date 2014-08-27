using NGL.Tests.Builders;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class ParentCourseToParentCourseJsonModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var entity = new ParentCourseBuilder().Build();
            var mapper = new ParentCourseToParentCourseJsonModelMapper();

            var model = mapper.Build(entity);

            model.LabelName.ShouldBe(entity.ParentCourseTitle);
            model.ValueName.ShouldBe(entity.ParentCourseTitle);
            model.Id.ShouldBe(entity.Id);
        }
    }
}
