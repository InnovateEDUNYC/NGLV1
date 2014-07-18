using System;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class ProfileModel
    {
        public int StudentUsi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public string Race { get; set; }
        public string HomeLanguage { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}