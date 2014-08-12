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
    public class AssessmentCreatePage : Page<CreateAssessmentModel>
    {
        public AssessmentIndexPage CreateAssessment(CreateAssessmentModel createAssessmentModel)
        {
            Input.Model(createAssessmentModel);
            return Navigate.To<AssessmentIndexPage>(By.ClassName("btn"));
        }
    }
}
