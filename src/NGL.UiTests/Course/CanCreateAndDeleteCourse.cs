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
        IWant = "I want to create and delete courses",
        SoThat = "So that I can manage what is offered each session")]
    public class CanCreateAndDeleteCourse
    {
        private HomePage _homePage;
        private CourseGenerationPage _courseGenerationPage;
        private CreateModel _createCourseModel;
        private CourseIndexPage _courseIndexPage;
        private CourseCreatePage _courseCreatePage;
        private int _coursesOnIndexPage;

        public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void GoToTheCreateCoursePage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _courseCreatePage = _courseGenerationPage.GoToCourseIndexPage().GoToCreatePage();
        }

        public void HaveEnteredValidInputForAllFields()
        {
            _createCourseModel = new CreateCourseModelBuilder().Build();
            _courseIndexPage = _courseCreatePage.CreateCourse(_createCourseModel);
        }

        public void ANewCourseShouldBeDisplayedOnTheCourseIndexPage()
        {
            var courseExists = _courseIndexPage.CourseExists(_createCourseModel);
            courseExists.ShouldBe(true);
        }

        private void CourseIsDeleted()
        {
            _coursesOnIndexPage = _courseIndexPage.GetNumberOfCourses();
            _courseIndexPage = _courseIndexPage.GoDelete(_createCourseModel.CourseCode);
        }

        private void TheCourseIsNotOnTheCourseIndexPage()
        {
            _courseIndexPage.GetNumberOfCourses().ShouldBe(_coursesOnIndexPage - 1);
        }

        [Fact]
        public void ShouldCreateCourse()
        {
            this.Given(_ => AdminHasLoggedIn())
                .And(_ => GoToTheCreateCoursePage())
                .When(_ => HaveEnteredValidInputForAllFields())
                .Then(_ => ANewCourseShouldBeDisplayedOnTheCourseIndexPage())
                .When(_ => CourseIsDeleted())
                .Then(_ => TheCourseIsNotOnTheCourseIndexPage())
                .BDDfy();
        }
    }
}