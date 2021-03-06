//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NGL.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParentCourse
    {
        public ParentCourse()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.Courses = new HashSet<Course>();
            this.ParentCourseGrades = new HashSet<ParentCourseGrade>();
        }
    
        public int EducationOrganizationId { get; set; }
        public string ParentCourseCode { get; set; }
        public string ParentCourseTitle { get; set; }
        public string ParentCourseDescription { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<ParentCourseGrade> ParentCourseGrades { get; set; }
    }
}
