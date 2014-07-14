using System;
using System.Linq;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class StudentIndexPage : Page
    {
        public EnrollmentPage GoToEnroll()
        {
            return Navigate.To<EnrollmentPage>(By.LinkText("Enroll a Student"));
        }

        public String LastUsiInTheList
        {
            get { return Find.Elements(By.CssSelector("tr:last-child td:last-child")).First().Text; }
        }
    }
}
