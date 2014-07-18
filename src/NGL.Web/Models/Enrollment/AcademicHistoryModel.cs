using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicHistoryModel
    {

        [Required]
        public decimal? Reading { get; set; }
        [Required]
        public decimal? Writing { get; set; }
        [Required]
        public decimal? Math { get; set; }
        [Required]
        public GradeLevelTypeEnum? AnticipatedGrade { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public String PerformanceHistory { get; set; }
        public HttpPostedFileBase PerformanceHistoryFile { get; set; }
    }
}