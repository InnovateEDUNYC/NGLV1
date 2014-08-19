using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.ParentCourse
{
    public class IndexModel
    {
        [Required]
        [StringLength(60)]
        public string ParentCourseCode { get; set; }
        [Required]
        [StringLength(60)]
        public string ParentCourseTitle { get; set; }
        public string ParentCourseDescription { get; set; }
    }
}