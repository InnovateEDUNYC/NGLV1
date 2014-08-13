using NGL.Web.Models.Assessment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Assessment
{
    public class AssessmentIndexPage : Page<IndexModel>
    {
        public AssessmentCreatePage GoToCreatePage()
        {
            return Navigate.To<AssessmentCreatePage>(By.LinkText("Create Assessment"));
        }

        public bool AssessmentExists(CreateModel createAssessmentModel)
        {
            return Find.Element(By.ClassName("assessment-title")).Text.Equals(createAssessmentModel.AssessmentTitle);
        }

        public AssessmentResultsPage GoToResultsPage()
        {
            return Navigate.To<AssessmentResultsPage>(By.LinkText("Results"));
        }
    }
}
