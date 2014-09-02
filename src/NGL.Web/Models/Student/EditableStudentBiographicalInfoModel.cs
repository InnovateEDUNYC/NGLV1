using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditableStudentBiographicalInfoModel
    {
        public int StudentUsi { get; set; }
        public SexTypeEnum Sex { get; set; }
        public string BirthDate { get; set; }

        [Display(Name = "Hispanic/Latino Ethnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        public string RaceForDisplay { get; set; }
        public RaceTypeEnum Race { get; set; }
        public LanguageDescriptorEnum HomeLanguage { get; set; }
    }
}