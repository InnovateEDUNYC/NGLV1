using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class EditHomeAddressPanel : Page<HomeAddressModel>
    {
        public void Edit(HomeAddressModel homeAddressModel)
        {
            Execute.Script("$('#Address').val('" + homeAddressModel.Address + "')");
            Execute.Script("$('#Address2').val('" + homeAddressModel.Address2 + "')");
            Execute.Script("$('#City').val('" + homeAddressModel.City + "')");
            Execute.Script("$('#State').val('" + homeAddressModel.State + "')");
            Execute.Script("$('#PostalCode').val('" + homeAddressModel.PostalCode + "')");

            Find.Element(By.Id("save-home-address-edit")).Click();
            WaitFor.AjaxCallsToComplete();
        }
    }
}