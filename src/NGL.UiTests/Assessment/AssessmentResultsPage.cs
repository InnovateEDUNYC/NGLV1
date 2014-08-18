﻿using System.Linq;
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

        public AssessmentIndexPage EnterResultsForFirstStudent(string score)
        {
            Find.Element(By.Id("StudentResults_0__AssessmentResult")).SendKeys(score);
            return Navigate.To<AssessmentIndexPage>(By.ClassName("btn"));
        }

        public bool ResultsExistForFirstStudent(string score)
        {
            return Find.Element(By.Id("StudentResults_0__AssessmentResult")).GetAttribute("value").Equals(score);
        }
    }
}