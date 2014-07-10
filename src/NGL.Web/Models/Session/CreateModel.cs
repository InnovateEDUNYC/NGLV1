using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;
using FluentValidation.Attributes;

namespace NGL.Web.Models.Session
{
    [Validator(typeof(CreateModelValidator))]
    public class CreateModel
    {
        public TermTypeEnum? Term { get; set; }

        public SchoolYearTypeEnum SchoolYear { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? BeginDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? EndDate { get; set; }

        public int? TotalInstructionalDays { get; set; }
    }
}