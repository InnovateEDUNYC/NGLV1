using System;
using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using Shouldly;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourseGrade
{
    public class ParentCourseGradesPage : Page<ParentCourseGradesModel>
    {
        public void SelectAParentCourseAndSession(string parentCourseId, int sessionId)
        {

            Execute.Script("$('#SessionId').val("+sessionId+");");
            Execute.Script("$('#SessionId').trigger('populated');");
            Execute.Script("$('#ParentCourseId').val('"+parentCourseId+"');");
            Execute.Script("$('#ParentCourseId').trigger('populated');");
        }

        public void EditGrades(string grade)
        {
            Find.Element(By.ClassName("btn-primary"));
            Navigate.To<ParentCourseGradesPage>(By.ClassName("btn-primary"));
            Execute.Script("$('#grade-0').val(" + grade + ");");
            Navigate.To<ParentCourseGradesPage>(By.ClassName("btn-primary"));
        }

        public void CheckGrades(string grade)
        {
            Find.Element(By.ClassName("table")).Text.Contains(grade).ShouldBe(true);
        }
    }
}
