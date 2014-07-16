﻿using NGL.UiTests.Shared;
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
        private SchedulingPage _schedulingPage;
        private CreateModel _createCourseModel;
        private CourseIndexPage _courseIndexPage;
        private CourseCreatePage _courseCreatePage;

        public void GivenIHaveLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.JohnSmith.ViewModel);
        }

        public void AndGivenIAmOnTheCreateCoursePage()
        {
            _schedulingPage = _homePage.TopMenu.GoToSchedulingPage();
            _courseCreatePage = _schedulingPage.GoToCourseIndexPage().GoToCreatePage();
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

            _courseIndexPage = _courseCreatePage.CreateCourse(_createCourseModel);
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