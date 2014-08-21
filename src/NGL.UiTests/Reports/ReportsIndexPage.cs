using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using NGL.UiTests.ParentCourse;
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
