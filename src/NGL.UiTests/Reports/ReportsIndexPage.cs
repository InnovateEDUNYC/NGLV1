using NGL.UiTests.ParentCourseGrade;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Reports
{
    public class ReportsIndexPage : Page<IndexModel>
    {
        public ParentCourseGradesPage GoToGrades()
        {

            return Navigate.To<ParentCourseGradesPage>(By.LinkText("Grade Students"));   
        }
    }
}
