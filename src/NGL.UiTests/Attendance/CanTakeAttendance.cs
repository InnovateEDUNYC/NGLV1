using NGL.Tests.Builders;
using NGL.UiTests.Enrollment;
using NGL.UiTests.Shared;
using NGL.UiTests.Student;
using NGL.Web.Data.Entities;
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
        private ProfilePage _profilePage;
        private StudentIndexPage _studentIndex;

        public TakeAttendancePage TakeAttendancePage
        {
            set { _takeAttendancePage = value; }
            get { return _takeAttendancePage; }
        }

        private void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }

        private void IAmOnTheTakeAttendancePage()
        {
            _takeAttendancePage = _homePage.TopMenu.GoToTakeAttendancePage();
        }

        private void IEnterAValidSessionSectionAndDate()
        {
            var takeAttendanceModel = new TakeAttendanceModelBuilder().Build();
            _takeAttendancePage = _takeAttendancePage.SearchForStudents(takeAttendanceModel);
        }

        private void AListOfStudentsAttendingThatSectionShouldShow()
        {
            _takeAttendancePage.GetStudentAttendance().Count.ShouldBeGreaterThan(0);
        }

        private void ISaveAfterMarkingAllTheStudentsTardy()
        {
            _takeAttendancePage = _takeAttendancePage.EnterAttendanceStatus(AttendanceEventCategoryDescriptorEnum.Tardy);
        }

        private void AllTheStudentsShouldBeMarkedTardy()
        {
            _takeAttendancePage.GetStudentAttendance().ShouldAllBe(sa => sa == "Tardy");
        }

        private void IVisitThatStudentsProfilePage()
        {
            _studentIndex = _homePage.TopMenu.GoToStudentsPage();
            _profilePage = _studentIndex.GoToProfilePage();
        }

        private void TheFlagCountShouldBe(int flagCount)
        {
            _profilePage.FlagCountIs(flagCount).ShouldBe(true);
        }

        private void IMarkAStudentPresentForTwoOtherDays()
        {
            _takeAttendancePage = _homePage.TopMenu.GoToTakeAttendancePage();
            _takeAttendancePage.MarkPresentForDate("09/10/2014");
            _takeAttendancePage.MarkPresentForDate("09/11/2014");
        }

        private void StudentProfilePageShouldDisplayTheAttendancePercentage()
        {
            _profilePage.AttendancePercentageIs("66%").ShouldBe(true);
        }

        private void IClearAllFlagsForEveryone()
        {
            _studentIndex = _homePage.TopMenu.GoToStudentsPage();
            _studentIndex.ClearFlags();
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
                .When(_ => IVisitThatStudentsProfilePage())
                .Then(_ => TheFlagCountShouldBe(1))
                .When(_ => IMarkAStudentPresentForTwoOtherDays())
                .And(_ => IVisitThatStudentsProfilePage())
                .Then(_ => StudentProfilePageShouldDisplayTheAttendancePercentage())
                .When(_ => IClearAllFlagsForEveryone())
                .And(_ => IVisitThatStudentsProfilePage())
                .Then(_ => TheFlagCountShouldBe(0))
                .BDDfy();
        }

    }
}
