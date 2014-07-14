using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class CreateModel
    {
        public CreateModel()
        {
            SchoolYear = (SchoolYearTypeEnum)DateTime.Today.Year;
        }

        [Required]
        public TermTypeEnum? Term { get; set; }

        [Required]
        public SchoolYearTypeEnum SchoolYear { get; set; }

        [Required]
        public DateTime? BeginDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public int? TotalInstructionalDays { get; set; }
    }
}
