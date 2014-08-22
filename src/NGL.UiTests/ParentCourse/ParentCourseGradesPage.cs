using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.UI;
using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseGradesPage : Page<ParentCourseGradesModel>
    {
        public void SelectAParentCourse()
        {
            Input.ReplaceInputValueWith(m => m.FindParentCourseModel.SessionId, 1);
            Input.ReplaceInputValueWith(m => m.FindParentCourseModel.SectionId, 7);
            Execute.Script("$('#SectionId').trigger('populated');");
        }

        public void EditGrades(string grade)
        {
            Navigate.To<ParentCourseGradesPage>(By.LinkText("Edit"));
            Input.ReplaceInputValueWith(m => m.ParentGradesModelList[0].Grade, grade);
            Navigate.To<ParentCourseGradesPage>(By.ClassName("btn-primary"));
        }

        public void CheckGrades(string grade)
        {
            Find.Element(By.CssSelector("tr:last-of-type studentGrade_Grade")).Text.Equals(grade);
        }
    }
}
