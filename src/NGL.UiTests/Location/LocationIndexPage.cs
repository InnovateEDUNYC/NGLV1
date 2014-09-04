using NGL.Web.Models.Location;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Location
{
    public class LocationIndexPage : Page<IndexModel>
    {

        public LocationCreatePage GoToCreatePage()
        {
            return Navigate.To<LocationCreatePage>(By.LinkText("Add Classroom"));
        }

        public bool LocationExists(CreateModel createModel)
        {
            var classroomIdCodeExists = Execute.ScriptAndReturn<string>("$('.classroom-code:contains(\"" + createModel.ClassroomIdentificationCode + "\")').text()");

            var maxSeatsExists = Execute.ScriptAndReturn<string>("$('.max-seats:contains(\"" + createModel.MaximumNumberOfSeats + "\")').text()");

            var optimalSeatsExists = Execute.ScriptAndReturn<string>("$('.optimal-seats:contains(\"" + createModel.OptimalNumberOfSeats + "\")').text()");

            return classroomIdCodeExists !=null && maxSeatsExists != null && optimalSeatsExists != null;
        }

        public void Delete(CreateModel locationCreateModel)
        {
            Execute.Script("$('.classroom-code:contains(\"" +locationCreateModel.ClassroomIdentificationCode + "\")').parent().find('.btn-primary').click()");
        }
    }
}
