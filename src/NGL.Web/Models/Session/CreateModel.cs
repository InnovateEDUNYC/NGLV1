using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class CreateModel
    {
        [Required]
        public TermTypeEnum? Term { get; set; }

        [Required]
        public SchoolYearTypeEnum SchoolYear { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime? BeginDate { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime? EndDate { get; set; }

        [Required]
        public int? TotalInstructionalDays { get; set; }

        public CreateModel()
        {
            SchoolYear = (SchoolYearTypeEnum) DateTime.Today.Year;
        }
    }
}