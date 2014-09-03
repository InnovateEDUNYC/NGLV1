using NGL.Tests.ClassPeriod;
using NGL.UiTests.Shared;
using NGL.Web.Models.ClassPeriod;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.ClassPeriod
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create periods",
        SoThat = "So that I know when different class sections are occuring")]
    public class CanCreateAndDeleteClassPeriod
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private ClassPeriodCreatePage _classPeriodCreatePage;
        private CreateModel _classPeriodCreateModel;
        private ClassPeriodIndexPage _classPeriodIndexPage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                   .NavigateToInitialPage<HomePage>()
                   .Login(ObjectMother.UserJohnSmith.ViewModel);   
        }

        public void AndGivenIAmOnTheCreateClassPeriodPage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _classPeriodCreatePage = _courseGenerationPage.GoToClassPeriodIndexPage().GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _classPeriodCreateModel = new CreateClassPeriodModelBuilder().WithName("Period X").Build();
            _classPeriodIndexPage = _classPeriodCreatePage.CreateClassPeriod(_classPeriodCreateModel);
        }

        public void ThenANewClassPeriodShouldBeDisplayedOnTheClassPeriodIndexPage()
        {
            var classPeriodExists = _classPeriodIndexPage.ClassPeriodExists(_classPeriodCreateModel);
            classPeriodExists.ShouldBe(true);
        }

        public void WhenIDeleteTheClassPeriod()
        {
            _classPeriodIndexPage.DeletePeriod(_classPeriodCreateModel);
        }

        public void ThenThePeriodShouldBeDeleted()
        {
            var classPeriodExists = _classPeriodIndexPage.ClassPeriodExists(_classPeriodCreateModel);
            classPeriodExists.ShouldBe(false);
        }

        [Fact]
        public void ShouldCreateClassPeriod()
        {
            this.Given(_ => GivenIHaveLoggedIn())
                .And(_ => AndGivenIAmOnTheCreateClassPeriodPage())
                .When(_ => WhenIHaveEnteredValidInputForAllFields())
                .Then(_ => ThenANewClassPeriodShouldBeDisplayedOnTheClassPeriodIndexPage())
                .When(_ => WhenIDeleteTheClassPeriod())
                .Then(_ => ThenThePeriodShouldBeDeleted())
                .BDDfy();
        }

    }
}
