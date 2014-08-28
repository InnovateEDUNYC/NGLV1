using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Student
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to edit student information",
        SoThat = "So that I can fix or update what's on their profile")]
    public class CanEditProfileInfo
    {
        private HomePage _homePage;
        private Web.Data.Entities.Student _student;
        private ProfilePage _profilePage;
        private EditStudentBiographicalInfoModel _newBiographicalInformation;

        private void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }
        private void IGoTTheStudentProfilePage()
        {
            _student = new StudentBuilder().Build();
            _profilePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage();

        }
        private void IEditAStudentsBiographicalInformation()
        {
            _newBiographicalInformation = new StudentBiographicalInformationModelBuilder().Build();
            var profileModel = new ProfileModel {BiographicalInfo = _newBiographicalInformation};
            _profilePage.EditBiographicalInfo(profileModel);
        }

        [Fact]
        public void ShouldEditProfileInfo()
        {
            this.Given(_ => IHaveLoggedIn())
                .When(_ => IGoTTheStudentProfilePage())
                .And(_ => IEditAStudentsBiographicalInformation())
                .Then(_ => IShouldSeeUpdatedInformation())
                
            .BDDfy();
        }

        private void IShouldSeeUpdatedInformation()
        {
            var canSeeUpdatedInformation = _profilePage.EditedBiographicalInformationIsVisable(_newBiographicalInformation);
            canSeeUpdatedInformation.ShouldBe(true);
        }
    }
}
