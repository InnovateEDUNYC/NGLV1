using System;
using NGL.UiTests.Shared;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.ParentCourseGrade
{
    [Story(
        AsA = "As an admin",
        IWant = "I want to enter grades for each student (at the parent course level)",
        SoThat = "So that I can submit grades to the state")]
    public class CanGradeParentCourseForStudent
    {
        private HomePage _homePage;
        private ParentCourseGradesPage _gradesPage;

        public void MasterAdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }

        public void GoToParentCourseGradesPage()
        {
            var reportsPage = _homePage.TopMenu.GoToReportsPage();
            _gradesPage = reportsPage.GoToGrades();
        }

        public void ValidGradesAreEntered()
        {
            _gradesPage.SelectAParentCourseAndSession("F43C1E50-1FEA-4D11-B98E-3DBA8AB22F18", 1);
            _gradesPage.EditGrades("100");
        }
        public void TheGradesAreSaved()
        {
            _gradesPage.CheckGrades("100");
        }

        [Fact]
        public void ShouldCreateCourseGrade()
        {
            this.Given(_ => MasterAdminHasLoggedIn())
                .And(_ => GoToParentCourseGradesPage())
                .When(_ => ValidGradesAreEntered())
                .Then(_ => TheGradesAreSaved())
                .BDDfy();
        }

    }
}
