using System.ComponentModel.DataAnnotations;

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

        public string FoodServiceEligibilityStatus { get; set; }
    }
}