using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModel
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
        public String Address { get; set; }

        [StringLength(20)]
        public String Address2 { get; set; }

        [Required]
        [StringLength(30)]
        public String City { get; set; }

        [Required]
        public SexTypeEnum? Sex { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        [Required]
        public RaceTypeEnum? Race { get; set; }

        [Required]
        public StateAbbreviationTypeEnum? State { get; set; }

        [Required]
        [StringLength(17)]
        public String PostalCode { get; set; }

        [Required]
        public LanguageDescriptorEnum? HomeLanguage { get; set; }

        public ParentEnrollmentInfoModel ParentEnrollmentInfoModel { get; set; }
    }
}