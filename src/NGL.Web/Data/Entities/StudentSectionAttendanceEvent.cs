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
    
    public partial class StudentSectionAttendanceEvent
    {
        public int StudentUSI { get; set; }
        public int SchoolId { get; set; }
        public string ClassPeriodName { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public string LocalCourseCode { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public System.DateTime EventDate { get; set; }
        public int AttendanceEventCategoryDescriptorId { get; set; }
        public string AttendanceEventReason { get; set; }
        public Nullable<int> EducationalEnvironmentTypeId { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AttendanceEventCategoryDescriptor AttendanceEventCategoryDescriptor { get; set; }
        public virtual EducationalEnvironmentType EducationalEnvironmentType { get; set; }
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
    }
}