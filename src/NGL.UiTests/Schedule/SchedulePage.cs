using System.Collections.Generic;
using System.Linq;
using NGL.Web.Models.Schedule;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

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
            var sectionIdDiv = Find.OptionalElement(By.ClassName("current-section-list-item"));
            return sectionIdDiv != null;
        }

        public List<string> GetSections()
        {
            WaitFor.AjaxCallsToComplete();

            return Find.Elements(By.ClassName("section-id")).Select(we => we.Text).ToList();            
        }

        public void RemoveSection(int sectionId)
        {
            Find.Element(By.CssSelector("[data-section-id='" + sectionId + "']")).Click();
        }
    }
}
