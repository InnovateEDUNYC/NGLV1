using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
