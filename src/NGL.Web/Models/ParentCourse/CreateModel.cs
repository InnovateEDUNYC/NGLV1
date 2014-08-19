using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.ParentCourse
{
    public class CreateModel
    {
        [Required]
        [StringLength(60)]
        public string ParentCourseCode { get; set; }
        [Required]
        [StringLength(60)]
        public string ParentCourseTitle { get; set; }
        [StringLength(20)]
        public string ParentCourseDescription { get; set; }
    }
}