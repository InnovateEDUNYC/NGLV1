using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditableParentAddressModel
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Display(Name="State")]
        public string StateForDisplay { get; set; }
        public StateAbbreviationTypeEnum? State { get; set; }
        public string PostalCode { get; set; }
    }
}