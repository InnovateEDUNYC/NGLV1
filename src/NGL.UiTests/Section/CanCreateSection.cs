using NGL.Tests.Section;
using NGL.UiTests.Shared;
using NGL.Web.Models.Section;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Section
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create a section",
        SoThat = "So that I can manage what is offered each session")]
    public class CanCreateSection
    {
        private HomePage _homePage;
        private SectionCreatePage _sectionCreatePage;
        private CreateModel _createSectionModel;
        private SectionIndexPage _sectionIndexPage;
        private int _sectionsCount;

        public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void GoToTheCreateSectionPage()
        {
            var sectionIndexPage = _homePage.TopMenu.GoToCourseGenerationPage().GoToSectionIndexPage();
            _sectionCreatePage = sectionIndexPage.GoToCreatePage();
        }

        public void HaveEnteredValidInputForAllFields()
        {
            _createSectionModel = new CreateSectionModelBuilder().Build();
            _sectionIndexPage = _sectionCreatePage.CreateSection(_createSectionModel);
        }

        public void ANewSectionShouldBeDisplayedOnTheSectionIndexPage()
        {
            var sectionExists = _sectionIndexPage.SectionExists(_createSectionModel);
            sectionExists.ShouldBe(true);
        }

        private void SectionIsDeleted()
        {
            _sectionsCount = _sectionIndexPage.GetNumberOfSections();
            _sectionIndexPage = _sectionIndexPage.GoDelete(_createSectionModel);
        }

        private void TheSectionIsNotOnTheSectionIndexPage()
        {
            _sectionIndexPage.GetNumberOfSections().ShouldBe(_sectionsCount - 1);
        }

        [Fact]
        public void ShouldCreateSection()
        {
            this.Given(_ => AdminHasLoggedIn())
                .And(_ => GoToTheCreateSectionPage())
                .When(_ => HaveEnteredValidInputForAllFields())
                .Then(_ => ANewSectionShouldBeDisplayedOnTheSectionIndexPage())
                .When(_ => SectionIsDeleted())
                .Then(_ => TheSectionIsNotOnTheSectionIndexPage())
                .BDDfy();
        }
    }
}
