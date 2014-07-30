using NGL.Tests.Builders;
using NGL.Web.Models.Section;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class EntityToListItemModelMapperTests
    {
        [Fact]
        public void ShouldMapClassPeriodToClassPeriodListItemModel()
        {
            var entity = new ClassPeriodBuilder().Build();
            var model = new ClassPeriodToClassPeriodListItemModelMapper().Build(entity);

            model.ClassPeriodName.ShouldBe(entity.ClassPeriodName);
        }

        [Fact]
        public void ShouldMapLocationToLocationListItemModel()
        {
            var entity = new LocationBuilder().Build();
            var model = new LocationToLocationListItemModelMapper().Build(entity);

            model.Classroom.ShouldBe(entity.ClassroomIdentificationCode);
        }

        [Fact]
        public void ShouldMapCourseToCourseListItemModel()
        {
            var entity = new CourseBuilder().Build();
            var model = new CourseToCourseListItemModelMapper().Build(entity);

            model.CourseCode.ShouldBe(entity.CourseCode);
            model.CourseTitle.ShouldBe(entity.CourseTitle);
        }

    }
}
