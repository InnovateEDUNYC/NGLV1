using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment.Parent;

namespace NGL.Web.Models.Enrollment.Student
{
    public class CreateStudentModel
    {
        [Display(Name = "Student USI")]
        public int? StudentUsi { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Address { get; set; }

        public String Address2 { get; set; }

        public String City { get; set; }

        public SexTypeEnum? Sex { get; set; }

        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        public RaceTypeEnum? Race { get; set; }

        public StateAbbreviationTypeEnum? State { get; set; }

        public String PostalCode { get; set; }

        public LanguageDescriptorEnum? HomeLanguage { get; set; }

        public ParentEnrollmentInfoModel FirstParent { get; set; }
    }
}