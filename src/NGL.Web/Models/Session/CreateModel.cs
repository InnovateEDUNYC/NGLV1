using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class CreateModel
    {
        [Required]
        public TermTypeEnum? Term { get; set; }

        [Required]
        public SchoolYearTypeEnum? SchoolYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime BeginDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime EndDate { get; set; }
        public int TotalInstructionalDays { get; set; }
    }
}