using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.UiTests.Enrollment;
using NGL.UiTests.Shared;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.ParentCourse
{
    [Story(
        AsA = "As a teacher",
        IWant = "I want to enter grades for each student (at the parent course level)",
        SoThat = "So that I can submit grades to the state")]
    public class CanGradeParentCourseForStudent
    {
        private HomePage _homePage;
        private ParentCourseGradesPage _gradesPage;

        public void IHaveLoggedInAsATeacher()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserHellenSmith.ViewModel);
        }

        public void GoToParentCourseGradesPage()
        {
            var reportsPage = _homePage.TopMenu.GoToReportsPage();
            _gradesPage = reportsPage.GoToGrades();
        }

        public void IEnterValidGrades()
        {
            _gradesPage.SelectAParentCourse();
            _gradesPage.EditGrades("100");
        }
        public void TheGradesAreSaved()
        {
            _gradesPage.CheckGrades("100");
        }

        [Fact (Skip = "not yet finished")]
        public void ShouldCreateCourse()
        {
            this.Given(_ => IHaveLoggedInAsATeacher())
                .And(_ => GoToParentCourseGradesPage())
                .When(_ => IEnterValidGrades())
                .Then(_ => TheGradesAreSaved())
                .BDDfy();
        }

    }
}
