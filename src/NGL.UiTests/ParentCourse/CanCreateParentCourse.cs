using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Tests.Course;
using NGL.UiTests.Shared;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.ParentCourse
{
        [Story(
        AsA = "As a school admin",
        IWant = "I want to create parent courses",
        SoThat = "So that I can manage what top level courses are offered")]
    public class CanCreateParentCourse
    {
            private HomePage _homePage;
            private CourseGenerationPage _courseGenerationPage;
            private ParentCourseCreatePage _parentCourseCreatePage;
            private CreateModel _createParentCourseModel;
            private ParentCourseIndexPage _parentCourseIndexPage;

            public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateParentCoursePage()
        {
            _courseGenerationPage = _homePage.TopMenu.GoToCourseGenerationPage();
            _parentCourseCreatePage = _courseGenerationPage.GoToParentCourseIndexPage().GoToCreatePage();
        }

        public void WhenIHaveEnteredValidInputForAllFields()
        {
            _createParentCourseModel = new CreateParentCourseModelBuilder().Build();
            _parentCourseIndexPage = _parentCourseCreatePage.CreateParentCourse(_createParentCourseModel);
        }

        public void ThenANewParentCourseShouldBeDisplayedOnTheParentCourseIndexPage()
        {
            var parentCourseExists = _parentCourseIndexPage.ParentCourseExists(_createParentCourseModel);
            parentCourseExists.ShouldBe(true);
        }

        [Fact(Skip="not yet implemented")]
        public void ShouldCreateCourse()
        {
            this.BDDfy();
        }
    }
}
