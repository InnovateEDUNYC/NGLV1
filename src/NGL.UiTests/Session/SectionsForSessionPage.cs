using System.Linq;
using NGL.UiTests.Section;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Session
{
    public class SectionsForSessionPage : Page
    {
        public int GetCourseCount()
        {
            return Find.Elements(By.ClassName("course")).Count();
        }

        public int GetSectionCountForFirstCourse()
        {
            Find.Element(By.ClassName("course")).Click();
            return Find.Element(By.Id("collapse-0")).FindElements(By.TagName("div")).Count;
        }

        public SectionCreatePage GoToCreateSectionPage()
        {
            return Navigate.To<SectionCreatePage>(By.LinkText("Create New"));
        }
    }
}