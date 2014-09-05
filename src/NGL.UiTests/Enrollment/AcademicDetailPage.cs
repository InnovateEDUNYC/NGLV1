using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    public class AcademicDetailPage : Page<AcademicDetailModel>
    {
        private const string AcademicDetailTitle = "Academic Details";

        public bool IsTitleCorrect()
        {
            return Find.Element(By.CssSelector("h2")).Text.Equals(AcademicDetailTitle);
        }

        public ProgramStatusPage InputDetails(AcademicDetailModel academicDetailModel)
        {
            Input.Model(academicDetailModel);
            return Navigate.To<ProgramStatusPage>(By.Id("submit-details"));
        }
    }
}
