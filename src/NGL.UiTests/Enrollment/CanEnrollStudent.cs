using System;
using NGL.Tests.Enrollment;
using NGL.UiTests.Shared;
using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using Shouldly;
using TestStack.BDDfy;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.PageObjects.Actions;
using Xunit;

namespace NGL.UiTests.Enrollment
{
    [Story(
        AsA = "As an operations associate",
        IWant = "I want to enter biographical information in student profile",
        SoThat = "So that I can have a record for each student"
        )]
    public class CanEnrollStudent
    {
        private HomePage _homePage;
        private EnrollmentPage _enrollmentPage;
        private ProfilePage _profilePage;
        private ProgramStatusPage _programStatusPage;
        private CreateStudentModel _createStudentModel;
        private AcademicDetailPage _academicDetailPage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void IAmOnTheEnrollPage()
        {
            _enrollmentPage = _homePage.TopMenu.GoToEnrollmentPage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _createStudentModel = StudentModelFactory.CreateStudent();

            _academicDetailPage = _enrollmentPage.Enroll(_createStudentModel);
        }

        private void IShouldArriveOnTheAcademicDetailPage()
        {
            _academicDetailPage.IsTitleCorrect().ShouldBe(true);
        }
        private void IHaveInputAcademicDetails()
        {

            var academicDetailModel = AcademicDetailModelFactory.CreateAcademicDetailModelWithPerformanceHistory();

            _programStatusPage = _academicDetailPage.InputDetails(academicDetailModel);
        }

        private void IShouldArriveOnTheProgramStatusPage()
        {
            _programStatusPage.IsTitleCorrect().ShouldBe(true);
        }

        private void IHaveInputProgramStatus()
        {
            var programStatusModel = EnterProgramStatusModelFactory.CreateProgramStatus();
            _profilePage = _programStatusPage.InputProgramStatus(programStatusModel);
        }

        private void IShouldBeAbleToViewTheStudentInfo()

        {
            var allFieldsExist = _profilePage.AllFieldsExist(_createStudentModel);
            allFieldsExist.ShouldBe(true);
        }
        [Fact]
        public void ShouldEnrollStudent()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheEnrollPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => IShouldArriveOnTheAcademicDetailPage())
                .When(_ => IHaveInputAcademicDetails())
                .Then(_ => IShouldArriveOnTheProgramStatusPage())
                .When(_ => IHaveInputProgramStatus())
                .Then(_ => IShouldBeAbleToViewTheStudentInfo())
                .BDDfy();
        }
    }
}
