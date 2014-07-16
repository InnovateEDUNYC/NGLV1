using NGL.Web.Models.Location;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Location
{
    public class LocationCreatePage : Page<CreateModel>
    {

        public LocationIndexPage CreateLocation(CreateModel createLocationModel)
        {
            Input.Model(createLocationModel);
            return Navigate.To<LocationIndexPage>(By.ClassName("btn"));
        }
    }
}
