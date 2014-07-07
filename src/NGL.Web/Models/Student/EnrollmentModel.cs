using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ChameleonForms.Attributes;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModel
    {
        [Required(ErrorMessage = "Please enter Student USI")]
        [Display(Name = "Student USI")]
        public int? StudentUsi { get; set; }

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

        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Please enter sex")]
        public SexTypeEnum? SexTypeEnum { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter birth date")]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        [Display(Name = "Race")]
        [Required(ErrorMessage = "Please enter old ethnicity type")]
        public OldEthnicityTypeEnum? OldEthnicityTypeEnum { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        [Display(Name = "State")]
        public StateAbbreviationTypeEnum? StateAbbreviationTypeEnum { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        [StringLength(17)]

        public String PostalCode { get; set; }

        [Display(Name = "Home Language")]
        [Required(ErrorMessage = "Please enter home language")]
        public LanguageDescriptorEnum? LanguageDescriptorEnum { get; set; }
    }
}