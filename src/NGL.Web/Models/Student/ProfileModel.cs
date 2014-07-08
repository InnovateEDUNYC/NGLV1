using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ProfileModel
    {
        public string FirstName { get; set; }
        public string LastSurname { get; set; }
        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public string Race { get; set; }
    }
}