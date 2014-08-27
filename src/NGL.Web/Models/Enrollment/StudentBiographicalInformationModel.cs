using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentBiographicalInformationModel
    {
        public int StudentUsi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypeEnum Sex { get; set; }
        public string BirthDate { get; set; }
        [Display(Name="Hispanic/Latino")]
        public bool HispanicLatinoEthnicity { get; set; }

        public string RaceForDisplay { get; set; }
        public RaceTypeEnum Race { get; set; }
        public LanguageDescriptorEnum HomeLanguage { get; set; }
    }
}