using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ProfileProgramStatusModel
    {
        public string TestingAccommodation { get; set; }
        public string TestingAccommodationFile { get; set; }
        public string BilingualProgram { get; set; }
        public string EnglishAsSecondLanguage { get; set; }
        public string Gifted { get; set; }
        public string SpecialEducation { get; set; }
        public string SpecialEducationFile { get; set; }
        public string TitleParticipation { get; set; }
        public string TitleParticipationFile { get; set; }

        [Display(Name = "McKinney Vento")]
        public string McKinneyVento { get; set; }
        public string McKinneyVentoFile { get; set; }

        [Display(Name = "Food services eligibility status")]
        public string FoodServicesEligibilityStatusForDisplay { get; set; }
        public SchoolFoodServicesEligibilityTypeEnum FoodServicesEligibilityStatus { get; set; }
    }
}