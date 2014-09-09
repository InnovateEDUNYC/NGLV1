using NGL.UiTests.Session;
using NGL.UiTests.Shared;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Section
{
    [Story(
        AsA = "As a school admin",
        IWant = "I want to see a list of the terms and school year",
        SoThat = "so that I can click on a term and add/view sections")]
    public class CanViewAndCreateSectionsForASession
    {
        private HomePage _homePage;
        private SessionIndexPage _sessionIndexPage;
        private SectionsForSessionPage _sectionsForSessionPage;
        private SectionCreatePage _sectionCreatePage;

        public void AdminHasLoggedIn()
        {
            _homePage = Host.Instance
                .NavigateToInitialPage<HomePage>()
                .Login(ObjectMother.UserJohnSmith.ViewModel);
        }
        public void GoToTheSessionIndexPage()
        {
            _sessionIndexPage = _homePage.TopMenu.GoToCourseGenerationPage().GoToSessionIndexPage();
        }

        public void GoToViewSectionsForFallSemester()
        {
            _sectionsForSessionPage = _sessionIndexPage.ViewSectionsFor("Fall Semester");
        }

        public void FiveCoursesShouldBeDisplayedOnThePage()
        {
            _sectionsForSessionPage.GetCourseCount().ShouldBe(5);
        }

        public void FirstCourseShouldHaveSections()
        {
            _sectionsForSessionPage.GetSectionCountForFirstCourse().ShouldBeGreaterThan(0);
        }
        public void NewSectionIsCreated()
        {
            _sectionCreatePage = _sectionsForSessionPage.GoToCreateSectionPage();
        }

        public void Fall2014IsSelectedByDefault()
        {
            _sectionCreatePage.GetSession().ShouldBe("Fall 2014");
        }

        [Fact]
        public void ShouldViewAndCreateSectionsForASession()
        {
            this.Given(_ => AdminHasLoggedIn())
                .And(_ => GoToTheSessionIndexPage())
                .When(_ => GoToViewSectionsForFallSemester())
                .Then(_ => FiveCoursesShouldBeDisplayedOnThePage())
                .Then(_ => FirstCourseShouldHaveSections())
                .When(_ => NewSectionIsCreated())
                .Then(_ => Fall2014IsSelectedByDefault())
                .BDDfy();
        }
    }
}
