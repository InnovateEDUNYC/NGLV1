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
        public void ShouldGroupByCourse()
        {
            _mathCourseName = "Math 101 - DI";
            _englishCourseName = "English 102 - CW";
            
            var session = new SessionBuilder()
                .WithSections(new []
                {
                    new SectionBuilder()
                        .WithLocalCourseCode(_mathCourseName)
                        .WithUniqueSectionCode("Math DI - 1")
                        .WithClassPeriodName("Period 1")
                        .WithClassroomIdentificationCode("Room 1").Build(),
                    new SectionBuilder()
                        .WithLocalCourseCode(_englishCourseName)
                        .WithUniqueSectionCode("English CW")
                        .WithClassPeriodName("Period 2")
                        .WithClassroomIdentificationCode("Room 2").Build(),
                    new SectionBuilder()
                        .WithLocalCourseCode(_mathCourseName)
                        .WithUniqueSectionCode("Math DI - 2")
                        .WithClassPeriodName("Period 1")
                        .WithClassroomIdentificationCode("Room 3").Build()
                }).Build();
            var model = new SessionToSessionWithSectionsModelMapper().Build(session);

            model.Id.ShouldBe(session.SessionIdentity);
            model.Name.ShouldBe(session.SessionName);
            model.CourseRows.Count.ShouldBe(2);

            var firstCourseRow = model.CourseRows[0];
            firstCourseRow.Name.ShouldBe(_mathCourseName);
            firstCourseRow.SectionRows.Count.ShouldBe(2);

            var firstSectionRow = firstCourseRow.SectionRows[0];
            firstSectionRow.UniqueSectionCode.ShouldBe("Math DI - 1");
            firstSectionRow.ClassPeriod.ShouldBe("Period 1");
            firstSectionRow.Location.ShouldBe("Room 1");

            var secondSectionRow = firstCourseRow.SectionRows[1];
            secondSectionRow.UniqueSectionCode.ShouldBe("Math DI - 2");
            secondSectionRow.ClassPeriod.ShouldBe("Period 1");
            secondSectionRow.Location.ShouldBe("Room 3");

            var secondCourseRow = model.CourseRows[1];
            secondCourseRow.Name.ShouldBe(_englishCourseName);
            secondCourseRow.SectionRows.Count.ShouldBe(1);
            var thirdSectionRow = secondCourseRow.SectionRows[0];
            thirdSectionRow.UniqueSectionCode.ShouldBe("English CW");
            thirdSectionRow.ClassPeriod.ShouldBe("Period 2");
            thirdSectionRow.Location.ShouldBe("Room 2");
        }

        [Fact]
        public void ShouldMapSessionWithNoSections()
        {
            var session = new SessionBuilder().Build();
            var model = new SessionToSessionWithSectionsModelMapper().Build(session);

            model.Name.ShouldBe(session.SessionName);
            model.CourseRows.Count.ShouldBe(0);
        }
    }
}
