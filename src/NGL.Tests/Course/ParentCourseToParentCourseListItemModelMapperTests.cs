using NGL.Tests.Builders;
using NGL.Web.Models.Course;
using Shouldly;
using Xunit;

namespace NGL.Tests.Course
{
    public class ParentCourseToParentCourseListItemModelMapperTests
    {
        [Fact]
        public void ShouldMapClassPeriodToClassPeriodListItemModel()
        {
            var entity = new ParentCourseBuilder().Build();
            var model = new ParentCourseToParentCourseListItemModelMapper().Build(entity);

            model.ParentCourseId.ShouldBe(entity.Id);
            model.ParentCourseTitle.ShouldBe(entity.ParentCourseTitle);
        }
    }
}
