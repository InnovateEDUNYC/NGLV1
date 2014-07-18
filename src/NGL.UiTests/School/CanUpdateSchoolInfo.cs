using System;
using NGL.UiTests.Shared;
using NGL.Web.Models.School;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.School
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to edit my school's details",
        SoThat = "So that I can change school information"
        )]
    public class CanUpdateSchoolInfo
    {
        private HomePage _homePage;
        private SchoolModel _schoolModel;
        private SchoolPage _schoolPage;
        private SchoolModel _updatedModel;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheSchoolEditPage()
        {
            _schoolPage = _homePage.TopMenu.GoToSchoolPage();
        }

        public void WhenIInputValidDetailsForMySchool()
        {
            var salt = Guid.NewGuid();
            _schoolModel = new SchoolModel
            {
                NameOfInstitution = "Name " + salt, 
                StateOrganizationId = "State " + salt, 
                WebSite = "website " + salt
            };

            _homePage = _schoolPage.Save(_schoolModel);
            _schoolPage = _homePage.TopMenu.GoToSchoolPage();
            _updatedModel = _schoolPage.Read.ModelFromPage();
        }

        public void ThenIShouldBeAbleToViewTheNewSchoolInfo()
        {
            _updatedModel.WebSite.ShouldBe(_schoolModel.WebSite);
            _updatedModel.NameOfInstitution.ShouldBe(_schoolModel.NameOfInstitution);
            _updatedModel.StateOrganizationId.ShouldBe(_schoolModel.StateOrganizationId);
        }

        [Fact]
        public void ShouldEditSchoolInfo()
        {
            this.BDDfy();
        }

    }
}
