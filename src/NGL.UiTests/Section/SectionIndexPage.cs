using NGL.Web.Models.Section;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Section
{
    public class SectionIndexPage : Page<IndexModel>
    {
        public SectionCreatePage GoToCreatePage()
        {
            return Navigate.To<SectionCreatePage>(By.LinkText("Create New Section"));
        }
    }
}
