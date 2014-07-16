using NGL.Web.Models.Location;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Location
{
    public class LocationIndexPage : Page<IndexModel>
    {

        public LocationCreatePage GoToCreatePage()
        {
            return Navigate.To<LocationCreatePage>(By.LinkText("Create New Classroom Location"));
        }

        public bool LocationExists(CreateModel createModel)
        {
            var classroomIdCodeExists =
                Find.Element(By.CssSelector("tr:nth-child(2) td.classroom-code")).Text.Equals(createModel.ClassroomIdentificationCode);


            var maxSeatsExists =
                Find.Element(By.CssSelector("tr:nth-child(2) td.max-seats")).Text.Equals(createModel.MaximumNumberOfSeats.ToString());


            var optimalSeatsExists =
                Find.Element(By.CssSelector("tr:nth-child(2) td.optimal-seats")).Text.Equals(createModel.OptimalNumberOfSeats.ToString());

            return classroomIdCodeExists && maxSeatsExists && optimalSeatsExists;
        }
    }
}
