using System.Linq;
using System.Web.UI;
using NGL.Web.Models.Assessment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Assessment
{
    public class AssessmentResultsPage : Page<EnterResultsModel>
    {
        public AssessmentIndexPage EnterResults(EnterResultsModel enterResultsModel)
        {
            Find.Element(By.Id("StudentResults_0__AssessmentResult")).SendKeys("94");
            return Navigate.To<AssessmentIndexPage>(By.ClassName("btn"));
        }
    }
}
