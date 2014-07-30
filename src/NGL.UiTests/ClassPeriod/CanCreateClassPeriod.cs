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
    public class CanCreateClassPeriod
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
            _classPeriodCreateModel = new CreateClassPeriodModelBuilder().Build();
            _classPeriodIndexPage = _classPeriodCreatePage.CreateClassPeriod(_classPeriodCreateModel);
        }

        public void ThenANewClassPeriodShouldBeDisplayedOnTheClassPeriodIndexPage()
        {
            var classPeriodExists = _classPeriodIndexPage.ClassPeriodExists(_classPeriodCreateModel);
            classPeriodExists.ShouldBe(true);
        }

        [Fact]
        public void ShouldCreateClassPeriod()
        {
            this.BDDfy();
        }

    }
}
