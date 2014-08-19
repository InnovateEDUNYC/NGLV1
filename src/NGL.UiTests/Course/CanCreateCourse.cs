using NGL.Tests.Course;
using NGL.UiTests.Shared;
using NGL.Web.Models.Course;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Course
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create courses",
        SoThat = "So that I can manage what is offered each session")]
    public class CanCreateCourse
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private CreateModel _createCourseModel;
        private CourseIndexPage _courseIndexPage;
        private CourseCreatePage _courseCreatePage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateCoursePage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _courseCreatePage = _courseGenerationPage.GoToCourseIndexPage().GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createCourseModel = new CreateCourseModelBuilder().Build();
            _courseIndexPage = _courseCreatePage.CreateCourse(_createCourseModel);
        }

        public void ThenANewCourseShouldBeDisplayedOnTheCourseIndexPage()
        {
            var courseExists = _courseIndexPage.CourseExists(_createCourseModel);
            courseExists.ShouldBe(true);
        }

        [Fact(Skip = "in middle of being changed to have parent course")]
        public void ShouldCreateCourse()
        {
            this.BDDfy();
        }
    }
}