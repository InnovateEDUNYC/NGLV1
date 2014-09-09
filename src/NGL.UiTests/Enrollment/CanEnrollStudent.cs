using NGL.Tests.Enrollment;
using NGL.UiTests.Shared;
using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using Shouldly;
using TestStack.BDDfy;
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

        public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void GoToTheEnrollPage()
        {
            _enrollmentPage = _homePage.TopMenu.GoToEnrollmentPage();
        }

        public void HaveEnteredValidInputForAllFields()
        {
            _createStudentModel = CreateStudentModelFactory.CreateStudent();
            _academicDetailPage = _enrollmentPage.Enroll(_createStudentModel);
        }

        private void ShouldArriveOnTheAcademicDetailPage()
        {
            _academicDetailPage.IsTitleCorrect().ShouldBe(true);
        }

        private void HaveInputAcademicDetails()
        {
            var academicDetailModel = CreateAcademicDetailModelFactory.CreateAcademicDetailModelWithPerformanceHistory();
            _programStatusPage = _academicDetailPage.InputDetails(academicDetailModel);
        }

        private void ShouldArriveOnTheProgramStatusPage()
        {
            _programStatusPage.IsTitleCorrect().ShouldBe(true);
        }

        private void ProgramStatusInputted()
        {
            var programStatusModel = new EnterProgramStatusModelBuilder().Build();
            _profilePage = _programStatusPage.InputProgramStatus(programStatusModel);
        }

        private void StudentInfoIsDisplayed()
        {
            var allFieldsExist = _profilePage.AllFieldsExist(_createStudentModel);
            allFieldsExist.ShouldBe(true);
        }

        [Fact]
        public void ShouldEnrollStudent()
        {
            this.Given(_ => AdminHasLoggedIn())
                .And(_ => GoToTheEnrollPage())
                .When(_ => HaveEnteredValidInputForAllFields())
                .Then(_ => ShouldArriveOnTheAcademicDetailPage())
                .When(_ => HaveInputAcademicDetails())
                .Then(_ => ShouldArriveOnTheProgramStatusPage())
                .When(_ => ProgramStatusInputted())
                .Then(_ => StudentInfoIsDisplayed())
                .BDDfy();
        }
    }
}
