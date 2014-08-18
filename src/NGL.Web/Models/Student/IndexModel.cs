using System;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class IndexModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        [Display(Name="Student USI")]
        public int StudentUsi { get; set; }

    }
}