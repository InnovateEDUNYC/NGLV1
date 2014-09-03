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
            var term = Execute.ScriptAndReturn<string>("$('.term:contains(\"" + createModel.Term.Humanize() + "\")').text()");
            var year = Execute.ScriptAndReturn<string>("$('.school-year:contains(\"" + createModel.SchoolYear.Humanize() + "\")').text()");

            return term != null && year != null;
        }

        public SectionsForSessionPage ViewSectionsFor(string sessionName)
        {
            return Navigate.To<SectionsForSessionPage>(By.CssSelector("[data-term='" + sessionName + "'] > td > a"));
        }

        public void DeleteSession(CreateModel createModel)
        {
            Execute.Script("$('.term:contains(\""+ createModel.Term.Humanize() + "\") + .school-year:contains(\"" + createModel.SchoolYear.Humanize() + "\")').parent().find('.btn-primary').click()");
        }
    }
}