using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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
            return Find.Element(By.CssSelector("td:first-of-type")).Text.Equals(createAssessmentModel.AssessmentTitle);
        }
    }
}
