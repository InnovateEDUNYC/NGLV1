using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class ProfileAcademicDetailModel
    {
        public decimal? ReadingScore { get; set; }
        public decimal? WritingScore { get; set; }
        public decimal? MathScore { get; set; }

        [Display(Name="Performance history file")]
        public string PerformanceHistoryFileUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string PerformanceHistory { get; set; }
        public int SchoolYear { get; set; }
    }
}