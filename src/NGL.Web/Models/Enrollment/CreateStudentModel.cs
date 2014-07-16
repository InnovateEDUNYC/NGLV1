using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModel
    {
        public static CreateStudentModel New()
        {
            return new CreateStudentModel
            {
                FirstParent = new CreateParentModel {SameAddressAsStudent = true},
                SecondParent = new CreateParentModel {SameAddressAsStudent = true}
            };
        }

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
        public CreateParentModel FirstParent { get; set; }
        public bool AddSecondParent { get; set; }
        public CreateParentModel SecondParent { get; set; }
    }
}