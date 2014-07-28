using NGL.Web.Models.Section;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Section
{
    public class SectionCreatePage : Page<CreateModel>
    {
        public SectionIndexPage CreateSection(CreateModel createSectionModel)
        {
            Input.Model(createSectionModel);
            return Navigate.To<SectionIndexPage>(By.ClassName("btn"));
        }
    }
}
