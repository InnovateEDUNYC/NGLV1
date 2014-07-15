using System.ComponentModel.DataAnnotations;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class EnterProgramStatusModel
    {
        [Required]
        public bool? TestingAccommodation { get; set; }
        public HttpPostedFileBase TestingAccommodationFile { get; set; }
        [Required]
        public bool? BilingualProgram { get; set; }
        [Required]
        public bool? EnglishAsSecondLanguage { get; set; }
        [Required]
        public bool? Gifted { get; set; }
        [Required]
        public bool? SpecialEducation { get; set; }
        public HttpPostedFileBase SpecialEducationFile { get; set; }
        [Required]
        public bool? TitleParticipation { get; set; }
        public HttpPostedFileBase TitleParticipationFile { get; set; }
        [Required]
        [Display(Name = "McKinney Vento")]
        public bool? McKinneyVento { get; set; }
        public HttpPostedFileBase McKinneyVentoFile { get; set; }
        public SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus { get; set; }
    }
}