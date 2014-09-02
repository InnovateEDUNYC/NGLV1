using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class EditAcademicDetailsPanel : Page<EditAcademicDetailModel>
    {
        public void Edit(EditAcademicDetailModel academicDetailModel)
        {
            Execute.Script("$('#AcademicDetail_MathScore').val('" + academicDetailModel.MathScore + "')");
            Execute.Script("$('#AcademicDetail_ReadingScore').val('" + academicDetailModel.ReadingScore + "')");
            Execute.Script("$('#AcademicDetail_WritingScore').val('" + academicDetailModel.WritingScore + "')");
            Execute.Script("$('#AcademicDetail_PerformanceHistory').val('" + academicDetailModel.PerformanceHistory + "')");

            Find.Element(By.Id("save-academic-details-edit")).Click();
            WaitFor.AjaxCallsToComplete();
        }
    }
}
