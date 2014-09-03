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
            var result = Execute.ScriptAndReturn<string>("$('.period-name:contains(\"" + createModel.ClassPeriodName + "\")').text()");

            return result != null;
        }

        public void DeletePeriod(CreateModel createModel)
        {
            var result = Execute.ScriptAndReturn<string>("$('.period-name:contains(\"" + createModel.ClassPeriodName + "\")').text()").Trim();
            Execute.Script("$('.period-name:contains(\"" + createModel.ClassPeriodName + "\") + td input').click()");
        }
    }
}
