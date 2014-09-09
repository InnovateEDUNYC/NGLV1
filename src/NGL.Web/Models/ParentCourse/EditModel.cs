using System;
using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.ParentCourse
{
    public class EditModel
 {
        [Required]
        [StringLength(60)]
        public string ParentCourseCode { get; set; }
        [Required]
        [StringLength(60)]
        public string ParentCourseTitle { get; set; }
        [StringLength(20)]
        public string ParentCourseDescription { get; set; }

        public Guid ParentCourseId { get; set; }
 }
}
