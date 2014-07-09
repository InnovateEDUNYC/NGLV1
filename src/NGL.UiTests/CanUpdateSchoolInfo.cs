using System;
using NGL.UiTests.Pages;
using NGL.Web.Models.Account;
using NGL.Web.Models.School;
using Shouldly;
using Xunit;

namespace NGL.UiTests
{
    public class CanUpdateSchoolInfo
    {
        private SchoolModel _schoolModel;

        [Fact]
        public void Verify()
        {
            var homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel);
        
            var schoolPage = homePage.TopMenu.GoToSchoolPage();

            var salt = Guid.NewGuid();
            _schoolModel = new SchoolModel
            {
                NameOfInstitution = "Name " + salt, 
                StateOrganizationId = "State " + salt, 
                WebSite = "website " + salt
            };
            schoolPage.Input.Model(_schoolModel); 
            homePage = schoolPage.Save();
            schoolPage = homePage.TopMenu.GoToSchoolPage();
            var updatedModel = schoolPage.Read.ModelFromPage();
            updatedModel.WebSite.ShouldBe(_schoolModel.WebSite);
            updatedModel.NameOfInstitution.ShouldBe(_schoolModel.NameOfInstitution);
            updatedModel.StateOrganizationId.ShouldBe(_schoolModel.StateOrganizationId);
        }
    }
}
