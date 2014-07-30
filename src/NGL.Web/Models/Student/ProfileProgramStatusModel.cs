using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class ProfileProgramStatusModel
    {
        public bool? TestingAccommodation { get; set; }
        public string TestingAccommodationFile { get; set; }
        public bool? BilingualProgram { get; set; }
        public bool? EnglishAsSecondLanguage { get; set; }
        public bool? Gifted { get; set; }
        public bool? SpecialEducation { get; set; }
        public string SpecialEducationFile { get; set; }
        public bool? TitleParticipation { get; set; }
        public string TitleParticipationFile { get; set; }
        [Display(Name = "McKinney Vento")]
        public bool? McKinneyVento { get; set; }
        public string McKinneyVentoFile { get; set; }

        public string FoodServiceEligibilityStatus { get; set; }
    }
}