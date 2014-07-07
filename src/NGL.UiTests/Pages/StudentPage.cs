using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    class StudentPage : Page
    {
        public EnrollmentPage GoToEnroll()
        {
            return Navigate.To<EnrollmentPage>(By.LinkText("Enroll a Student"));
        }

        public String GetUsiStringOfLastStudentOnTable()
        {
            return Find.Elements(By.CssSelector("tr:last-child td:last-child")).First().Text;
        }
    }
}
