using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class EditProgramStatusPanel : Page<EnterProgramStatusModel>
    {
        public ProfilePage Edit(EnterProgramStatusModel programStatusModel)
        {
            Execute.Script("$('Input[name=\"ProgramStatus.TestingAccommodation\"][value=\"" + programStatusModel.TestingAccommodation +"\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.BilingualProgram\"][value=\"" + programStatusModel.BilingualProgram + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.EnglishAsSecondLanguage\"][value=\"" + programStatusModel.EnglishAsSecondLanguage + "\"]').click()");
            Execute.Script("$('#ProgramStatus_FoodServicesEligibilityStatus').val('" +
                           programStatusModel.FoodServicesEligibilityStatus + "')");
                
            Execute.Script("$('Input[name=\"ProgramStatus.Gifted\"][value=\"" + programStatusModel.Gifted + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.SpecialEducation\"][value=\"" + programStatusModel.SpecialEducation + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.TitleParticipation\"][value=\"" + programStatusModel.TitleParticipation + "\"]').click()");
            Execute.Script("$('Input[name=\"ProgramStatus.McKinneyVento\"][value=\"" + programStatusModel.McKinneyVento + "\"]').click()");
            return Navigate.To<ProfilePage>(By.Id("submit-program-status"));
        }
    }
}
