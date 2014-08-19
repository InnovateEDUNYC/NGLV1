using System;
using NGL.Web.Models.Course;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Course
{
    public class CourseCreatePage : Page<CreateModel>
    {
        public CourseIndexPage CreateCourse(CreateModel createCourseModel)
        {
            var parentCourseId = GetParentCourseId();

            Input.SelectByOptionValueInDropDown(m => m.ParentCourseId, parentCourseId);

            Input.ReplaceInputValueWith(m => m.CourseCode, createCourseModel.CourseCode);
            Input.ReplaceInputValueWith(m => m.CourseTitle, createCourseModel.CourseTitle);
            Input.ReplaceInputValueWith(m => m.NumberOfParts, createCourseModel.NumberOfParts);
            Input.ReplaceInputValueWith(m => m.AcademicSubject, createCourseModel.AcademicSubject);
            Input.ReplaceInputValueWith(m => m.CourseDescription, createCourseModel.CourseDescription);
            Input.ReplaceInputValueWith(m => m.DateCourseAdopted, createCourseModel.DateCourseAdopted);
            Input.ReplaceInputValueWith(m => m.HighSchoolCourseRequirement, createCourseModel.HighSchoolCourseRequirement);
            Input.ReplaceInputValueWith(m => m.CourseGPAApplicability, createCourseModel.CourseGPAApplicability);
            Input.ReplaceInputValueWith(m => m.CourseDefinedBy, createCourseModel.CourseDefinedBy);
            Input.ReplaceInputValueWith(m => m.MinimumAvailableCreditType, createCourseModel.MinimumAvailableCreditType);
            Input.ReplaceInputValueWith(m => m.MinimumAvailableCreditConversion, createCourseModel.MinimumAvailableCreditConversion);
            Input.ReplaceInputValueWith(m => m.MinimumAvailableCredit, createCourseModel.MinimumAvailableCredit);
            Input.ReplaceInputValueWith(m => m.MaximumAvailableCreditType, createCourseModel.MaximumAvailableCreditType);
            Input.ReplaceInputValueWith(m => m.MaximumAvailableCreditConversion, createCourseModel.MaximumAvailableCreditConversion);
            Input.ReplaceInputValueWith(m => m.MaximumAvailableCredit, createCourseModel.MaximumAvailableCredit);
            Input.ReplaceInputValueWith(m => m.CareerPathway, createCourseModel.CareerPathway);
            Input.ReplaceInputValueWith(m => m.TimeRequiredForCompletion, createCourseModel.TimeRequiredForCompletion);

            return Navigate.To<CourseIndexPage>(By.ClassName("btn"));
        }

        private Guid GetParentCourseId()
        {
            var parentCourseDropdown = Browser.FindElement(By.Id("ParentCourseId"));
            var parentCourseFirstOption = parentCourseDropdown.FindElement(By.TagName("option"));
            var parentCourseId = parentCourseFirstOption.GetAttribute("value");
            return Guid.Parse(parentCourseId);
        }
    }
}