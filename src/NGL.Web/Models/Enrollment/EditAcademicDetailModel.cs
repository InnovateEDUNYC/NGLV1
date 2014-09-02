using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NGL.Web.Models.Enrollment
{
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