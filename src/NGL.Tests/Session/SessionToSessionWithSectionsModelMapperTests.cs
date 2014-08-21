using NGL.Tests.Builders;
using NGL.Web.Models.Session;
using Shouldly;
using Xunit;

namespace NGL.Tests.Session
{
    public class SessionToSessionWithSectionsModelMapperTests
    {
        private string _mathCourseName;
        private string _englishCourseName;

        [Fact]
        public void ShouldMap()
        {
            _mathCourseName = "Math 101 - DI";
            _englishCourseName = "English 102 - CW";
            var session = new SessionBuilder()
                .WithSections(new []
                {
                    new SectionBuilder().WithLocalCourseCode(_mathCourseName).Build(),
                    new SectionBuilder().WithLocalCourseCode(_englishCourseName).Build(),
                    new SectionBuilder().WithLocalCourseCode(_mathCourseName).Build()
                }).Build();
            var model = new SessionToSessionWithSectionsModelMapper().Build(session);

            model.Name.ShouldBe(session.SessionName);
            model.CourseRows.Count.ShouldBe(2);
            model.CourseRows[0].Name.ShouldBe(_mathCourseName);
            model.CourseRows[1].Name.ShouldBe(_englishCourseName);
        }
    }
}
