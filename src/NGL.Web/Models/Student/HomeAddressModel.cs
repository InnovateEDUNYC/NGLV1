using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class HomeAddressModel
    {
        public int StudentUsi { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public StateAbbreviationTypeEnum? State { get; set; }
        public string PostalCode { get; set; }
    }
}