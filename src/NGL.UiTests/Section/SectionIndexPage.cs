//using NGL.Web.Models.Section;
//using OpenQA.Selenium;
//using TestStack.Seleno.PageObjects;
//
//namespace NGL.UiTests.Section
//{
//    public class SectionIndexPage : Page<IndexModel>
//    {
//        public SectionCreatePage GoToCreatePage()
//        {
//            return Navigate.To<SectionCreatePage>(By.LinkText("Create New Section"));
//        }
//
//        public bool SectionExists(CreateModel createSectionModel)
//        {
//            var sectionCodeExists =
//            Find.Element(By.CssSelector("tr:last-of-type td.section-code")).Text.Equals(createSectionModel.UniqueSectionCode);
//
//            return sectionCodeExists;
//        }
//    }
//}
