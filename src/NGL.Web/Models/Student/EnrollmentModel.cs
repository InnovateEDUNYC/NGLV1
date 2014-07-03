using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ChameleonForms.Attributes;
using NGL.Web.Annotations;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Student
{
    public class EnrollmentModel
    {
        private readonly ILookupRepository _lookupRepository = DependencyResolver.Current.GetService<ILookupRepository>();
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

        [ExistsIn("SexTypes", "SexTypeId", "ShortDescription")]
        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Please enter sex")]
        public int? SexTypeId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter birth date")]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        [Display(Name = "Race")]
        [ExistsIn("OldEthnicityTypes", "OldEthnicityTypeId", "ShortDescription")]
        [Required(ErrorMessage = "Please enter old ethnicity type")]
        public int? OldEthnicityTypeId { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        [Display(Name = "State")]
        [ExistsIn("StateAbbreviationTypes", "StateAbbreviationTypeId", "ShortDescription")]
        public int? StateAbbreviationTypeId { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        [StringLength(17)]

        public String PostalCode { get; set; }

        [Display(Name = "Home Language")]
        [ExistsIn("LanguageTypes", "LanguageTypeId", "ShortDescription")]
        [Required(ErrorMessage = "Please enter home language")]
        public int? LanguageTypeId { get; set; }
        public List<OldEthnicityType> OldEthnicityTypes
        {
            get
            {
                return _lookupRepository.GetAll<OldEthnicityType>().ToList();
            }
        }
        public List<StateAbbreviationType> StateAbbreviationTypes
        {
            get
            {
                return _lookupRepository.GetAll<StateAbbreviationType>().ToList();
            }
        }
        public List<LanguageType> LanguageTypes
        {
            get
            {
                return _lookupRepository.GetAll<LanguageType>().ToList();
            }
        }

        public List<SexType> SexTypes
        {
            get
            {
                return _lookupRepository.GetAll<SexType>().ToList();
            }
        }

    }
}