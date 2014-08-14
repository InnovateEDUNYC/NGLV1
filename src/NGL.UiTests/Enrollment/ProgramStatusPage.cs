using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    public class ProgramStatusPage : Page<EnterProgramStatusModel>
    {
        private const string PageTitle = "Program Status";

        public bool IsTitleCorrect()
        {
            return Find.Element(By.CssSelector("h2.title")).Text.Equals(PageTitle);
        }

        public ProfilePage InputProgramStatus(EnterProgramStatusModel programStatusModel)
        {
            Input.Model(programStatusModel);
            Input.SelectButtonInRadioGroup(m => m.McKinneyVento, programStatusModel.McKinneyVento);
            Input.SelectButtonInRadioGroup(m => m.TestingAccommodation, programStatusModel.TestingAccommodation);
            Input.SelectButtonInRadioGroup(m => m.BilingualProgram, programStatusModel.BilingualProgram);
            Input.SelectButtonInRadioGroup(m => m.EnglishAsSecondLanguage, programStatusModel.EnglishAsSecondLanguage);
            Input.SelectButtonInRadioGroup(m => m.SpecialEducation, programStatusModel.SpecialEducation);
            Input.SelectButtonInRadioGroup(m => m.Gifted, programStatusModel.Gifted);
            Input.SelectButtonInRadioGroup(m => m.TitleParticipation, programStatusModel.TitleParticipation);
            return Navigate.To<ProfilePage>(By.ClassName("btn"));
        }
    }
}
