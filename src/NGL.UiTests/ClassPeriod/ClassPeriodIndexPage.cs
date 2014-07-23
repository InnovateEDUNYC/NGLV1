using NGL.Web.Models.ClassPeriod;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ClassPeriod
{
    public class ClassPeriodIndexPage : Page<IndexModel>
    {

        public ClassPeriodCreatePage GoToCreatePage()
        {
            return Navigate.To<ClassPeriodCreatePage>(By.LinkText("Add Period"));
        }

        public bool ClassPeriodExists(CreateModel createModel)
        {
            return Find.Element(By.CssSelector("tr:last-of-type td.period-name")).Text.Equals(createModel.ClassPeriodName);
        }

    }
}
