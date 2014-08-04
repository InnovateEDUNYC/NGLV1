using NGL.Tests.Builders;
using NGL.Web.Models.Section;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class CourseToCourseJsonModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var entity = new CourseBuilder().Build();
            var model = new CourseToCourseJsonModelMapper().Build(entity);

            model.CourseCode.ShouldBe(entity.CourseCode);
            model.CourseTitle.ShouldBe(entity.CourseTitle);
        }
    }
}
