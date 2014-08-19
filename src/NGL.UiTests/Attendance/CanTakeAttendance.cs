using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Attendance
{
    [Story(
        AsA = "As a teacher",
        IWant = "I want to view a list of all my students as present And check those who are absent or tardy",
        SoThat = "So that I can record the students' attendance and track the student over time")]
    public class CanTakeAttendance
    {
        private HomePage _homePage;
        private TakeAttendancePage _takeAttendancePage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }

        public void IAmOnTheTakeAttendancePage()
        {
            _takeAttendancePage = _homePage.TopMenu.GoToTakeAttendancePage();
        }

        public void IEnterAValidSessionSectionAndDate()
        {
            var takeAttendanceModel = new TakeAttendanceModelBuilder().Build();
            _takeAttendancePage = _takeAttendancePage.SearchForStudents(takeAttendanceModel);
        }

        public void AListOfStudentsAttendingThatSectionShouldShow()
        {
            _takeAttendancePage.GetStudentAttendance().Count.ShouldBeGreaterThan(0);
        }

        public void ISaveAfterMarkingAllTheStudentsTardy()
        {
            _takeAttendancePage = _takeAttendancePage.EnterAttendanceStatus();
        }

        public void AllTheStudentsShouldBeMarkedTardy()
        {
            _takeAttendancePage.GetStudentAttendance().ShouldAllBe(sa => sa == "Tardy");
        }

        [Fact]
        public void ShouldTakeAttendance()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheTakeAttendancePage())
                .When(_ => IEnterAValidSessionSectionAndDate())
                .Then(_ => AListOfStudentsAttendingThatSectionShouldShow())
                .When(_ => ISaveAfterMarkingAllTheStudentsTardy())
                .Then(_ => AllTheStudentsShouldBeMarkedTardy())
                .BDDfy();
        }
    }
}
