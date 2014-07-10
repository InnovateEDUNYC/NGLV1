using System;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class ProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public string Race { get; set; }
    }
}