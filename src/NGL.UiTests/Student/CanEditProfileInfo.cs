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
        private EditableStudentBiographicalInfoModel _newBiographicalInformation;
        private NameModel _nameModel;
        private EnterProgramStatusModel _enterProgramStatusModel;
        private HomeAddressModel _homeAddressModel;
        private EditAcademicDetailModel _editAcademicDetailsModel;
        private EditProfileParentModel _parentModel;

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

        private void IEditTheAcademicDetails()
        {
            var editAcademicDetailsPanel = _profilePage.EditAcademicDetails();

            _editAcademicDetailsModel = new EditAcademicDetailsModelBuilder().Build();
            editAcademicDetailsPanel.Edit(_editAcademicDetailsModel);
        }

        private void IShouldSeeUpdatedAcademicDetails()
        {
            _profilePage.IsAcademicDetailAccordingTo(_editAcademicDetailsModel);
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
            var canSeeUpdateProgramStatus = _profilePage.IsProgramStatusInfoSameAs(_enterProgramStatusModel);
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
            _profilePage.IsHomeAddressSameAs(_homeAddressModel).ShouldBe(true);
        }

        private void IEditDetailsForParent(int parentNumber)
        {
            var editParentPanel = _profilePage.EditParent(parentNumber);
            _parentModel = new EditProfileParentModelBuilder().Build();
            if (parentNumber > 1)
            {
                _parentModel = new EditProfileParentModelBuilder().WithNewValues().Build();
            }
            editParentPanel.Edit(parentNumber, _parentModel);
        }

        private void IShouldSeeUpdatedParentDetailsFor(int parentNumber)
        {
            _profilePage.IsParentSameAs(parentNumber, _parentModel).ShouldBe(true);
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
                .When(_ => IEditTheAcademicDetails())
                .Then(_ => IShouldSeeUpdatedAcademicDetails())
                .When(_ => IEditTheProgramStatusInformation())
                .Then(_ => IShouldSeeUpdatedProgramStatusInformation())
                .When(_ => IEditTheHomeAddress())
                .Then(_ => IShouldSeeUpdatedHomeAddress())
                .When(_ => IEditDetailsForParent(1))
                .Then(_ => IShouldSeeUpdatedParentDetailsFor(1))
                .When(_ => IEditDetailsForParent(2))
                .Then(_ => IShouldSeeUpdatedParentDetailsFor(2))

                .BDDfy();
        }
    }
}
