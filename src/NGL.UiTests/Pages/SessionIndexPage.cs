using Humanizer;
using NGL.Web.Models.Session;
using OpenQA.Selenium;
using Shouldly;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    public class SessionIndexPage : Page<IndexModel>
    {
        public SessionCreatePage GoToCreatePage()
        {
            return Navigate.To<SessionCreatePage>(By.LinkText("Create New Session"));
        }

        public bool sessionExists(CreateModel createModel)
        {
            var termExists = Find.Element(By.CssSelector("td.term")).Text.Equals(createModel.Term.Humanize());
            var yearExists =
                Find.Element(By.CssSelector("td.school-year")).Text.Equals(createModel.SchoolYear.Humanize());

            Find.Element(By.CssSelector("td.term")).Text.ShouldBe(createModel.Term.Humanize());

            return termExists && yearExists;
        }
    }
}