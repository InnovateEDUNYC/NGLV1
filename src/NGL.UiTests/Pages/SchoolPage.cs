using NGL.Web.Models.School;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    class SchoolPage : Page<SchoolModel>
    {
        public HomePage Save()
        {
            return Navigate.To<HomePage>(By.ClassName("btn"));
        }
    }
}