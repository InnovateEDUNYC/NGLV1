using System;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModel
    {
        public int StudentUSI { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(75)]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(75)]
        [Display(Name = "Last Name")]
        public String LastSurname { get; set; }

        [Required(ErrorMessage = "Please enter street address")]
        [StringLength(150)]
        [Display(Name = "Home Address")]
        public String StreetNumberName { get; set; }

        [StringLength(20)]
        [Display(Name = "Address 2")]
        public String ApartmentRoomSuiteNumber { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [StringLength(30)]
        public String City { get; set; }

        public int SexTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        [Required(ErrorMessage = "Please enter old ethnicity type")]
        public int OldEthnicityTypeId { get; set; }

        [Required(ErrorMessage = "Please enter Student ID number")]
        [StringLength(16)]
        public String Id { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        
        public int StateAbbreviationTypeId { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        [StringLength(17)]
        public String PostalCode { get; set; }
        [Display(Name = "Race")]
        public int RaceTypeId { get; set; }
        public int LanguageDescriptorId { get; set; }
        public int LanguageUseTypeId { get; set; }

    }
}