using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModel
    {
        public AcademicDetailModel()
        {
            SchoolYear = (SchoolYearTypeEnum)DateTime.Today.Year;
        }
        public int StudentUsi { get; set; }
        public decimal? Reading { get; set; }
        public decimal? Writing { get; set; }
        public decimal? Math { get; set; }

        public SchoolYearTypeEnum SchoolYear { get; set; }
        public GradeLevelTypeEnum? AnticipatedGrade { get; set; }

        [DataType(DataType.MultilineText)]
        public String PerformanceHistory { get; set; }
        public HttpPostedFileBase PerformanceHistoryFile { get; set; }
        public DateTime? EntryDate { get; set; }
    }
    
    public class EditAcademicDetailModel
    {
        public int StudentUsi { get; set; }
        public decimal? ReadingScore { get; set; }
        public decimal? WritingScore { get; set; }
        public decimal? MathScore { get; set; }

        [Display(Name = "Performance History File")]
        public HttpPostedFileBase PerformanceHistoryFileUrl { get; set; }
        [DataType(DataType.MultilineText)]
        public string PerformanceHistory { get; set; }
        public int SchoolYear { get; set; }
    }
}