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

        private void MasterAdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserMasterAdmin.ViewModel);
        }
        private void GoToTheStudentProfilePage()
        {
            _profilePage = _homePage.TopMenu.GoToStudentsPage().GoToProfilePage();

        }
        private void StudentsBiographicalInformationIsEdited()
        {
            _newBiographicalInformation = new StudentBiographicalInformationModelBuilder().Build();
            var profileModel = new ProfileModel {BiographicalInfo = _newBiographicalInformation};
            _profilePage.EditBiographicalInfo(profileModel);
        }
        public void StudentNameIsEdited()
        {
            _nameModel = new NameModel
            {
                FirstName = "New",
                LastName = "Beginning"
            };
            _profilePage.EditName(_nameModel);
        }

        private void AcademicDetailsAreEdited()
        {
            var editAcademicDetailsPanel = _profilePage.EditAcademicDetails();

            _editAcademicDetailsModel = new EditAcademicDetailsModelBuilder().Build();
            editAcademicDetailsPanel.Edit(_editAcademicDetailsModel);
        }

        private void UpdatedAcademicDetailsAreVisible()
        {
            _profilePage.IsAcademicDetailAccordingTo(_editAcademicDetailsModel);
        }

        private void UpdatedBiographicalInformationIsVisible()
        {
            var canSeeUpdatedInformation = _profilePage.EditedBiographicalInformationIsVisable(_newBiographicalInformation);
            canSeeUpdatedInformation.ShouldBe(true);
        }

        private void UpdatedNameIsVisible()
        {
            _profilePage.EditedNameIsVisible(_nameModel).ShouldBe(true);
        }

        private void ProgramStatusInformationIsEdited()
        {
            var editProgramStatusPanel = _profilePage.EditProgramStatus();

            _enterProgramStatusModel = new EnterProgramStatusModelBuilder().WithTestingAccommodation(true).WithMcKinneyVento(false).Build();
            _profilePage = editProgramStatusPanel.Edit(_enterProgramStatusModel);
        }

        private void UpdatedProgramStatusInformationIsVisible()
        {
            var canSeeUpdateProgramStatus = _profilePage.IsProgramStatusInfoSameAs(_enterProgramStatusModel);
            canSeeUpdateProgramStatus.ShouldBe(true);
        }

        private void HomeAddressIsEdited()
        {
            var editHomeAddressPanel = _profilePage.EditHomeAddress();

            _homeAddressModel = new HomeAddressModelBuilder().Build();
            editHomeAddressPanel.Edit(_homeAddressModel);
        }

        private void UpdatedHomeAddressIsVisible()
        {
            _profilePage.IsHomeAddressSameAs(_homeAddressModel).ShouldBe(true);
        }

        private void DetailsForParentAreEdited(int parentNumber)
        {
            var editParentPanel = _profilePage.EditParent(parentNumber);
            _parentModel = new EditProfileParentModelBuilder().Build();
            if (parentNumber > 1)
            {
                _parentModel = new EditProfileParentModelBuilder().WithNewValues().Build();
            }
            editParentPanel.Edit(parentNumber, _parentModel);
        }

        private void UpdatedParentDetailsAreEdited(int parentNumber)
        {
            _profilePage.IsParentSameAs(parentNumber, _parentModel).ShouldBe(true);
        }

        [Fact]
        public void ShouldEditProfileInfo()
        {
            this.Given(_ => MasterAdminHasLoggedIn())
                .When(_ => GoToTheStudentProfilePage())
                .And(_ => StudentsBiographicalInformationIsEdited())
                .Then(_ => UpdatedBiographicalInformationIsVisible())
                .And(_ => StudentNameIsEdited())
                .Then(_ => UpdatedNameIsVisible())
                .When(_ => AcademicDetailsAreEdited())
                .Then(_ => UpdatedAcademicDetailsAreVisible())
                .When(_ => ProgramStatusInformationIsEdited())
                .Then(_ => UpdatedProgramStatusInformationIsVisible())
                .When(_ => HomeAddressIsEdited())
                .Then(_ => UpdatedHomeAddressIsVisible())
                .When(_ => DetailsForParentAreEdited(1))
                .Then(_ => UpdatedParentDetailsAreEdited(1))
                .When(_ => DetailsForParentAreEdited(2))
                .Then(_ => UpdatedParentDetailsAreEdited(2))

                .BDDfy();
        }
    }
}
