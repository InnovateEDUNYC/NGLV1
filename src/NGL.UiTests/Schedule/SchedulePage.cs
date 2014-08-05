using System.Web.UI;
using NGL.Web.Models.Schedule;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Actions;

namespace NGL.UiTests.Schedule
{
    public class SchedulePage : Page<SetModel>
    {
        public void AddStudentToSection(SetModel setModel)
        {
            Input.Model(setModel);
            var submitButton = Find.Element(By.Id("schedule-student-button"));

            submitButton.Click();
        }

        public bool SectionIsVisible()
        {
            WaitFor.AjaxCallsToComplete();
            var sectionIdDiv = Find.Element(By.ClassName("current-section-list-item"));
            return sectionIdDiv != null;
        }
    }
}
