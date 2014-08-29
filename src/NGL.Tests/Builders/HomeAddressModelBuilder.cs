using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Tests.Builders
{
    public class HomeAddressModelBuilder
    {
        private const int StudentUsi = 2000;
        private const string Address = "501 Belmont Ave";
        private const string Address2 = "Unit 3";
        private const string City = "Chicago";
        private readonly StateAbbreviationTypeEnum? State = StateAbbreviationTypeEnum.IL;
        private const string PostalCode = "60657";

        public HomeAddressModel Build()
        {
            return new HomeAddressModel
            {
                StudentUsi = StudentUsi,
                Address = Address,
                Address2 = Address2,
                City = City,
                State = State,
                PostalCode = PostalCode
            };
        }
    }
}