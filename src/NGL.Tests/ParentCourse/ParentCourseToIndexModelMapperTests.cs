using NGL.Tests.Builders;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class ParentCourseToIndexModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var parentCourseModel = new ParentCourseBuilder().Build();
            var indexModel = new ParentCourseToIndexModelMapper().Build(parentCourseModel);

            indexModel.ParentCourseCode.ShouldBe(parentCourseModel.ParentCourseCode);
            indexModel.ParentCourseTitle.ShouldBe(parentCourseModel.ParentCourseTitle);
            indexModel.ParentCourseDescription.ShouldBe(parentCourseModel.ParentCourseDescription);
        }
    }
}
