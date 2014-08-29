using NGL.Tests.Builders;
using NGL.Tests.Enrollment;
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
        private ProfilePage _profilePage;
        private EditStudentBiographicalInfoModel _newBiographicalInformation;
        private NameModel _nameModel;
        private EnterProgramStatusModel _enterProgramStatusModel;
        private HomeAddressModel _homeAddressModel;

        private void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }
        private void IGoTTheStudentProfilePage()
        {
            _profilePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage();

        }
        private void IEditAStudentsBiographicalInformation()
        {
            _newBiographicalInformation = new StudentBiographicalInformationModelBuilder().Build();
            var profileModel = new ProfileModel {BiographicalInfo = _newBiographicalInformation};
            _profilePage.EditBiographicalInfo(profileModel);
        }
        public void IEditTheStudentName()
        {
            _nameModel = new NameModel
            {
                FirstName = "New",
                LastName = "Beginning"
            };
            _profilePage.EditName(_nameModel);
        }
        private void IShouldSeeUpdatedBiographicalInformation()
        {
            var canSeeUpdatedInformation = _profilePage.EditedBiographicalInformationIsVisable(_newBiographicalInformation);
            canSeeUpdatedInformation.ShouldBe(true);
        }

        private void IShouldSeeUpdatedInformation()
        {
            var canSeeUpdatedInformation = _profilePage.EditedBiographicalInformationIsVisable(_newBiographicalInformation);
            canSeeUpdatedInformation.ShouldBe(true);
        }
        private void IShouldSeeUpdatedName()
        {
            _profilePage.EditedNameIsVisible(_nameModel).ShouldBe(true);
        }

        private void IEditTheProgramStatusInformation()
        {
            var editProgramStatusPanel = _profilePage.EditProgramStatus();

            _enterProgramStatusModel = new EnterProgramStatusModelBuilder().WithTestingAccommodation(true).WithMcKinneyVento(false).Build();
            _profilePage = editProgramStatusPanel.Edit(_enterProgramStatusModel);
        }

        private void IShouldSeeUpdatedProgramStatusInformation()
        {
            var canSeeUpdateProgramStatus = _profilePage.IsProgramStatusInfoAccordingTo(_enterProgramStatusModel);
            canSeeUpdateProgramStatus.ShouldBe(true);
        }

        private void IEditTheHomeAddress()
        {
            var editHomeAddressPanel = _profilePage.EditHomeAddress();

            _homeAddressModel = new HomeAddressModelBuilder().Build();
            editHomeAddressPanel.Edit(_homeAddressModel);
        }

        private void IShouldSeeUpdatedHomeAddress()
        {
            _profilePage.IsHomeAddressAccordingTo(_homeAddressModel).ShouldBe(true);
        }

        [Fact]
        public void ShouldEditProfileInfo()
        {
            this.Given(_ => IHaveLoggedIn())
                .When(_ => IGoTTheStudentProfilePage())
                .And(_ => IEditAStudentsBiographicalInformation())
                .Then(_ => IShouldSeeUpdatedBiographicalInformation())
                .And(_ => IEditTheStudentName())
                .Then(_ => IShouldSeeUpdatedName())
                .When(_ => IEditTheProgramStatusInformation())
                .Then(_ => IShouldSeeUpdatedProgramStatusInformation())
                .When(_ => IEditTheHomeAddress())
                .Then(_ => IShouldSeeUpdatedHomeAddress())

                .BDDfy();
        }
    }
}
