using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Assessment
{
    public class AssessmentCreatePage : Page<CreateAssessmentModel>
    {
        public AssessmentIndexPage CreateAssessment(CreateAssessmentModel createAssessmentModel)
        {
            Input.ReplaceInputValueWith(m => m.SessionId, 1);
            Input.ReplaceInputValueWith(m => m.SectionId, 2);
            Input.ReplaceInputValueWith(m => m.AssessmentTitle, createAssessmentModel.AssessmentTitle);
            Input.ReplaceInputValueWith(m => m.AdministeredDate, createAssessmentModel.AdministeredDate.Value.ToShortDateString());
            Input.SelectByOptionTextInDropDown(m => m.QuestionType, createAssessmentModel.QuestionType.Humanize());
            Input.SelectByOptionTextInDropDown(m => m.GradeLevel, createAssessmentModel.GradeLevel.Humanize());
            Input.ReplaceInputValueWith(m => m.Mastery, createAssessmentModel.Mastery);
            Input.ReplaceInputValueWith(m => m.NearMastery, createAssessmentModel.NearMastery);

            return Navigate.To<AssessmentIndexPage>(By.ClassName("btn"));
        }
    }
}
