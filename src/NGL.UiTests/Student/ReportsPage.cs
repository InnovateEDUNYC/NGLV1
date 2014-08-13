using System.Web.UI;
using NGL.Web.Models.Assessment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class ReportsPage : Page<AssessmentResultModel>
    {
        public ReportsPage GoToResultsPage()
        {
            return Navigate.To<ReportsPage>(By.LinkText("Reports"));
        }
    }
}
