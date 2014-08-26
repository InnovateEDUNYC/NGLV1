using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentModel
    {
        public int StudentUsi;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypeEnum Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
    }
}