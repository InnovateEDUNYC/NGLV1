using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourseGrade
{
    public class ParentCourseGradesPage : Page<ParentCourseGradesModel>
    {
        public void SelectAParentCourse()
        {
            Execute.Script("$('#SectionId').val(7);");
            Execute.Script("$('#SectionId').trigger('populated');");
        }

        public void EditGrades(string grade)
        {
            Find.Element(By.ClassName("btn-primary"));
            Navigate.To<ParentCourseGradesPage>(By.ClassName("btn-primary"));
//            Input.ReplaceInputValueWith(m => m.ParentGradesModelList[0].Grade, grade);
            Execute.Script("$('#grade-0').val(" + grade + ");");
            Navigate.To<ParentCourseGradesPage>(By.ClassName("btn-primary"));
        }

        public void CheckGrades(string grade)
        {
            Find.Element(By.ClassName("table")).Text.Contains(grade);
        }
    }
}
