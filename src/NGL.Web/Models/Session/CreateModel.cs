using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;
using FluentValidation.Attributes;

namespace NGL.Web.Models.Session
{
    [Validator(typeof(CreateModelValidator))]
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
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? BeginDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? EndDate { get; set; }

        [Required]
        public int? TotalInstructionalDays { get; set; }
    }
}