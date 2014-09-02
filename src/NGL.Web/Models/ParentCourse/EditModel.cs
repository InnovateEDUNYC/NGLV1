using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
