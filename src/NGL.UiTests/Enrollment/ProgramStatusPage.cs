using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class ProgramStatusPage : Page<EnterProgramStatusModel>
    {
        private const string PageTitle = "Program Status";

        public bool IsTitleCorrect()
        {
            return Find.Element(By.CssSelector("h2.title")).Text.Equals(PageTitle);
        }

        public ProfilePage InputProgramStatus(EnterProgramStatusModel programStatusModel)
        {
            Input.Model(programStatusModel);
            return Navigate.To<ProfilePage>(By.ClassName("btn"));
        }
    }
}
