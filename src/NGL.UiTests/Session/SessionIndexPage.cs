using Humanizer;
using NGL.Web.Models.Session;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Session
{
    public class SessionIndexPage : Page<IndexModel>
    {
        public SessionCreatePage GoToCreatePage()
        {
            return Navigate.To<SessionCreatePage>(By.LinkText("Create New Session"));
        }

        public bool SessionExists(CreateModel createModel)
        {
            var termExists = Find.Element(By.CssSelector("tr:last-of-type td.term")).Text.Equals(createModel.Term.Humanize());
            var yearExists =
                Find.Element(By.CssSelector("tr:last-of-type td.school-year")).Text.Equals(createModel.SchoolYear.Humanize());

            return termExists && yearExists;
        }

        public SectionsForSessionPage ViewSectionsFor(string sessionName)
        {
            return Navigate.To<SectionsForSessionPage>(By.CssSelector("[data-term='" + sessionName + "'] > td > a"));
        }
    }
}