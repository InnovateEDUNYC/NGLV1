using NGL.Tests.Builders;
using NGL.UiTests.Shared;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.ParentCourse
{
        [Story(
        AsA = "As a school admin",
        IWant = "I want to create, edit, and delete parent courses",
        SoThat = "So that I can manage what top level courses are offered")]
    public class CanCreateEditAndDeleteParentCourse
    {
            private HomePage _homePage;
            private CourseGenerationPage _courseGenerationPage;
            private ParentCourseCreatePage _parentCourseCreatePage;
            private CreateModel _createParentCourseModel;
            private ParentCourseIndexPage _parentCourseIndexPage;
            private EditModel _editParentCourseModel;
            private int _parentCoursesOnIndexPage;

            public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void GoToTheCreateParentCoursePage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _parentCourseCreatePage = _courseGenerationPage.GoToParentCourseIndexPage().GoToCreatePage();
        }

        public void HaveEnteredValidInputForAllFields()
        {
            _createParentCourseModel = new CreateParentCourseModelBuilder().Build();
            _parentCourseIndexPage = _parentCourseCreatePage.CreateParentCourse(_createParentCourseModel);
        }

        public void ANewParentCourseShouldBeDisplayedOnTheParentCourseIndexPage()
        {
            var parentCourseExists = _parentCourseIndexPage.ParentCourseExists(_createParentCourseModel);
            parentCourseExists.ShouldBe(true);
        }

        public void ParentCourseIsEdited()
        {
            _editParentCourseModel = new EditParentCourseModelBuilder().Build();
            var parentCourseEditPage = _parentCourseIndexPage.GoToEditPage();
            _parentCourseIndexPage = parentCourseEditPage.EditParentCourse(_editParentCourseModel);

        }

        public void TheParentCourseIsUpdatedOnTheParentCourseIndexPage()
        {
            var parentCourseChanged = _parentCourseIndexPage.ParentCourseExists(_editParentCourseModel);
            parentCourseChanged.ShouldBe(true);
        }

        public void ParentCourseIsDeleted()
        {
            _parentCoursesOnIndexPage = _parentCourseIndexPage.GetNumberOfParentCourses();
            _parentCourseIndexPage = _parentCourseIndexPage.GoDelete(_createParentCourseModel.ParentCourseCode);
        }

        public void TheParentCourseIsNotOnTheParentCourseIndexPage()
        {
            _parentCourseIndexPage.GetNumberOfParentCourses().ShouldBe(_parentCoursesOnIndexPage - 1);
        }

            [Fact]
        public void ShouldCreateCourse()
        {
            this.Given(_ => AdminHasLoggedIn())
               .And(_ => GoToTheCreateParentCoursePage())
               .When(_ => HaveEnteredValidInputForAllFields())
               .Then(_ => ANewParentCourseShouldBeDisplayedOnTheParentCourseIndexPage())
               .When(_ => ParentCourseIsEdited())
               .Then(_ => TheParentCourseIsUpdatedOnTheParentCourseIndexPage())
               .When(_ => ParentCourseIsDeleted())
               .Then(_ => TheParentCourseIsNotOnTheParentCourseIndexPage())
               .BDDfy();
        }
    }
}
