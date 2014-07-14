using NGL.Web.Models.Course;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Pages
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to create courses",
        SoThat = "So that I can manage what is offered each session")]
    public class CanCreateCourse
    {
        private HomePage _homePage;
        private CourseCreatePage _courseCreatePage;
        private CreateModel _createCourseModel;
        private CourseIndexPage _courseIndexPage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateCoursePage()
        {
            _courseCreatePage = _homePage.TopMenu.GoToCourseCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createCourseModel = new CreateModel
            {
                CourseCode = ObjectMother.Math101.CourseCode,
                CourseTitle = ObjectMother.Math101.CourseTitle,
                NumberOfParts = ObjectMother.Math101.NumberOfParts,
                CourseDescription = ObjectMother.Math101.CourseDescription
            };
            _courseCreatePage.Input.Model(_createCourseModel);
            _courseIndexPage = _courseCreatePage.CreateCourse();
        }

        public void ThenANewCourseShouldBeDisplayedOnTheCourseIndexPage()
        {
            bool coureExists = _courseIndexPage.CourseExists(_createCourseModel);

            coureExists.ShouldBe(true);
        }

        [Fact]
        public void ShouldCreateCourse()
        {
            this.BDDfy();
        }



    }
}