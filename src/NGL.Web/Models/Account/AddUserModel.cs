using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Account
{
    public class AddUserModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public ApplicationRole Role { get; set; }
        [Display(Name = "Staff USI")]
        public int? StaffUSI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HispanicLatino { get; set; }
        public OldEthnicityTypeEnum? OldEthnicityType { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string MaidenName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public SexTypeEnum? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PersonalEmail { get; set; }
        public LevelOfEducationDescriptorEnum? HighestCompletedLevelOfEducation { get; set; }
        public int? YearsOfPriorProfessionalExperience { get; set; }
        public int? YearsOfPriorTeachingExperience { get; set; }
        public bool? HighlyQualified { get; set; }
        public CitizenshipStatusTypeEnum? CitizenshipStatus { get; set; }
        [Display(Name = "Teacher USI")]
        public int? TeacherUSI { get; set; }
        [Display(Name = "SSN")]
        public string SSN { get; set; }
        public string Certificate1 { get; set; }
        public string Certificate2 { get; set; }
        public string Certificate3 { get; set; }
        public string Certificate4 { get; set; }
        public bool CriminalBackgroundCheck { get; set; }
        public bool Fingerprinted { get; set; }
    }
}