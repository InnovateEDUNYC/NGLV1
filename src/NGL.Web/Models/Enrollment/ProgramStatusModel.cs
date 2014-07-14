using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class ProgramStatusModel
    {
        [Required]
        public bool? TestingAccommodation { get; set; }
        public string TestingAccommodationFile { get; set; }
        [Required]
        public bool? BilingualProgram { get; set; }
        [Required]
        public bool? EnglishAsSecondLanguage { get; set; }
        [Required]
        public bool? Gifted { get; set; }
        [Required]
        public bool? SpecialEducation { get; set; }
        public string SpecialEducationFile { get; set; }
        [Required]
        public bool? TitleParticipation { get; set; }
        public string TitleParticipationFile { get; set; }
        [Required]
        [Display(Name = "McKinney Vento")]
        public bool? McKinneyVento { get; set; }
        public string McKinneyVentoFileUrl { get; set; }
        public SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus { get; set; }
    }
}