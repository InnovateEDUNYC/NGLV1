using System.Linq;
using System.Security;
using System.Web.UI;
using NGL.UiTests.Shared;
using NGL.Web.Models.Assessment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Assessment
{
    public class AssessmentResultsPage : Page<EnterResultsModel>
    {
        private string _score = "94";

        public AssessmentIndexPage EnterResults()
        {
            Find.Element(By.Id("StudentResults_0__AssessmentResult")).SendKeys(_score);
            return Navigate.To<AssessmentIndexPage>(By.ClassName("btn"));
        }

        public bool ResultsExist()
        {
            return Find.Element(By.Id("StudentResults_0__AssessmentResult")).GetAttribute("value").Equals(_score);
        }
    }
}
