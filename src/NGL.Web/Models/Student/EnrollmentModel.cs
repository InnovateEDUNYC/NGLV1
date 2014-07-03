using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private ILookupRepository _lookupRepository = DependencyResolver.Current.GetService<ILookupRepository>();
        public int StudentUsi { get; set; }

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

        public List<SexType> SexTypes
        {
            get
            {
                return _lookupRepository.GetAll<SexType>().ToList();
            }
        }

        [ExistsIn("SexTypes", "SexTypeId", "ShortDescription")]
        public int SexTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        public List<OldEthnicityType> OldEthnicityTypes
        {
            get
            {
                return _lookupRepository.GetAll<OldEthnicityType>().ToList();
            }
        }

        [Display(Name = "Old Ethnicity")]
        [ExistsIn("OldEthnicityTypes", "OldEthnicityTypeId", "ShortDescription")]
        [Required(ErrorMessage = "Please enter old ethnicity type")]
        public int OldEthnicityTypeId { get; set; }

        [Required(ErrorMessage = "Please enter Student ID number")]
        [StringLength(16)]
        public String Id { get; set; }

        [Required(ErrorMessage = "Please enter state")]

        public List<StateAbbreviationType> StateAbbreviationTypes
        {
            get
            {
                return _lookupRepository.GetAll<StateAbbreviationType>().ToList();
            }
        }

        [Display(Name = "State")]
        [ExistsIn("StateAbbreviationTypes", "StateAbbreviationTypeId", "ShortDescription")]
        public int StateAbbreviationTypeId { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        [StringLength(17)]

        public String PostalCode { get; set; }

        public List<RaceType> RaceTypes
        {
            get
            {
                return _lookupRepository.GetAll<RaceType>().ToList();
            }
        }

        [Display(Name = "Race")]
        [ExistsIn("RaceTypes", "RaceTypeId", "ShortDescription")]
        public int RaceTypeId { get; set; }

        public List<LanguageType> LanguageTypes
        {
            get
            {
                return _lookupRepository.GetAll<LanguageType>().ToList();
            }
        }


        [Display(Name = "Home Language")]
        [ExistsIn("LanguageTypes", "LanguageTypeId", "ShortDescription")]
        public int LanguageTypeId { get; set; }

        public int LanguageUseTypeId { get; set; }

    }
}