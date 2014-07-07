using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModel
    {
        [Required]
        [Display(Name = "Student USI")]
        public int? StudentUsi { get; set; }

        [Required]
        [StringLength(75)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public String LastName { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Home Address")]
        public String StreetNumberName { get; set; }

        [StringLength(20)]
        [Display(Name = "Address 2")]
        public String ApartmentRoomSuiteNumber { get; set; }

        [Required]
        [StringLength(30)]
        public String City { get; set; }

        [Display(Name = "Sex")]
        [Required]
        public SexTypeEnum? SexTypeEnum { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        [Display(Name = "Race")]
        [Required]
        public OldEthnicityTypeEnum? OldEthnicityTypeEnum { get; set; }

        [Required]
        [Display(Name = "State")]
        public StateAbbreviationTypeEnum? StateAbbreviationTypeEnum { get; set; }

        [Required]
        [StringLength(17)]
        public String PostalCode { get; set; }

        [Display(Name = "Home Language")]
        [Required]
        public LanguageDescriptorEnum? LanguageDescriptorEnum { get; set; }
    }
}