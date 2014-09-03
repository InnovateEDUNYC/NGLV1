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
        IWant = "I want to create and delete periods",
        SoThat = "So that I know when different class sections are occuring")]
    public class CanCreateAndDeleteClassPeriod
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private ClassPeriodCreatePage _classPeriodCreatePage;
        private CreateModel _classPeriodCreateModel;
        private ClassPeriodIndexPage _classPeriodIndexPage;

        public void IHaveLoggedIn()
        {
            _homePage = Host.Instance
                   .NavigateToInitialPage<HomePage>()
                   .Login(ObjectMother.UserJohnSmith.ViewModel);   
        }

        public void IAmOnTheCreateClassPeriodPage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _classPeriodCreatePage = _courseGenerationPage.GoToClassPeriodIndexPage().GoToCreatePage();
        }

        public void IHaveEnteredValidInputForAllFields()
        {
            _classPeriodCreateModel = new CreateClassPeriodModelBuilder().WithName("Period X").Build();
            _classPeriodIndexPage = _classPeriodCreatePage.CreateClassPeriod(_classPeriodCreateModel);
        }

        public void ANewClassPeriodShouldBeDisplayedOnTheClassPeriodIndexPage()
        {
            _classPeriodIndexPage.ClassPeriodExists(_classPeriodCreateModel).ShouldBe(true);
        }

        public void IDeleteTheClassPeriod()
        {
            _classPeriodIndexPage.DeletePeriod(_classPeriodCreateModel);
        }

        public void ThePeriodShouldBeDeleted()
        {
            _classPeriodIndexPage.ClassPeriodExists(_classPeriodCreateModel).ShouldBe(false);
        }

        [Fact]
        public void ShouldCreateClassPeriod()
        {
            this.Given(_ => IHaveLoggedIn())
                .And(_ => IAmOnTheCreateClassPeriodPage())
                .When(_ => IHaveEnteredValidInputForAllFields())
                .Then(_ => ANewClassPeriodShouldBeDisplayedOnTheClassPeriodIndexPage())
                .When(_ => IDeleteTheClassPeriod())
                .Then(_ => ThePeriodShouldBeDeleted())
                .BDDfy();
        }

    }
}
