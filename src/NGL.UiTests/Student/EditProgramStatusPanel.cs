using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class EditProgramStatusPanel : Page<EnterProgramStatusModel>
    {
        public ProfilePage Edit(EnterProgramStatusModel programStatusModel)
        {
            Execute.Script("$('Input[name=\"ProgramStatus.TestingAccommodation\"][value=\"" + programStatusModel.TestingAccommodation.ToString().ToLower() +"\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.BilingualProgram\"][value=\"" + programStatusModel.BilingualProgram.ToString().ToLower() + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.EnglishAsSecondLanguage\"][value=\"" + programStatusModel.EnglishAsSecondLanguage.ToString().ToLower() + "\"]').click()");
            Execute.Script("$('#ProgramStatus_FoodServicesEligibilityStatus').val('" +
                           programStatusModel.FoodServicesEligibilityStatus + "')");

            Execute.Script("$('Input[name=\"ProgramStatus.Gifted\"][value=\"" + programStatusModel.Gifted.ToString().ToLower() + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.SpecialEducation\"][value=\"" + programStatusModel.SpecialEducation.ToString().ToLower() + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.TitleParticipation\"][value=\"" + programStatusModel.TitleParticipation.ToString().ToLower() + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.McKinneyVento\"][value=\"" + programStatusModel.McKinneyVento.ToString().ToLower() + "\"]').click()");

            return Navigate.To<ProfilePage>(By.Id("save-program-status-edit"));
        }
    }
}
