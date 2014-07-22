﻿using NGL.UiTests.Student;
using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class ProgramStatusPage : Page<EnterProgramStatusModel>
    {
        private const string PageTitle = "Program Status";

        public bool IsTitleCorrect()
        {
            return Find.Element(By.CssSelector("h2.title")).Text.Equals(PageTitle);
        }

        public ProfilePage InputProgramStatus(EnterProgramStatusModel programStatusModel)
        {
            Input.Model(programStatusModel);
            Input.SelectButtonInRadioGroup(m => m.McKinneyVento, programStatusModel.McKinneyVento);
            Input.SelectButtonInRadioGroup(m => m.TestingAccommodation, programStatusModel.TestingAccommodation);
            Input.SelectButtonInRadioGroup(m => m.BilingualProgram, programStatusModel.BilingualProgram);
            Input.SelectButtonInRadioGroup(m => m.EnglishAsSecondLanguage, programStatusModel.EnglishAsSecondLanguage);
            Input.SelectButtonInRadioGroup(m => m.SpecialEducation, programStatusModel.SpecialEducation);
            Input.SelectButtonInRadioGroup(m => m.Gifted, programStatusModel.Gifted);
            return Navigate.To<ProfilePage>(By.ClassName("btn"));
        }
    }
}
