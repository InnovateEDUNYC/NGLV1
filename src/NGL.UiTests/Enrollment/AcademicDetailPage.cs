using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class AcademicDetailPage : Page<AcademicDetailModel>
    {
        private const string AcademicDetailTitle = "Academic Details";

        public bool IsTitleCorrect()
        {
            return Find.Element(By.CssSelector("h2.title")).Text.Equals(AcademicDetailTitle);
        }
    }
}
