using NGL.Web.Models.Section;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Section
{
    public class SectionCreatePage : Page<CreateModel>
    {
        public SectionIndexPage CreateSection(CreateModel createSectionModel)
        {
            Input.ReplaceInputValueWith(m => m.Session, createSectionModel.Session);
            Input.ReplaceInputValueWith(m => m.Course, createSectionModel.Course);
            Input.ReplaceInputValueWith(m => m.UniqueSectionCode, createSectionModel.UniqueSectionCode);
            
            Input.SelectByOptionTextInDropDown(m => m.Period, createSectionModel.Period);
            Input.SelectByOptionTextInDropDown(m => m.Classroom, createSectionModel.Classroom);

            Input.ReplaceInputValueWith(m => m.SessionId, createSectionModel.SessionId);

            return Navigate.To<SectionIndexPage>(By.ClassName("btn"));
        }
    }
}
