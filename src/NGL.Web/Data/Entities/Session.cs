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
    
    public partial class Session
    {
        public Session()
        {
            this.CourseOfferings = new HashSet<CourseOffering>();
            this.Sections = new HashSet<Section>();
            this.SessionAcademicWeeks = new HashSet<SessionAcademicWeek>();
            this.SessionGradingPeriods = new HashSet<SessionGradingPeriod>();
            this.StudentSchoolAttendanceEvents = new HashSet<StudentSchoolAttendanceEvent>();
        }
    
        public int SchoolId { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string SessionName { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TotalInstructionalDays { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
        public virtual School School { get; set; }
        public virtual SchoolYearType SchoolYearType { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual TermType TermType { get; set; }
        public virtual ICollection<SessionAcademicWeek> SessionAcademicWeeks { get; set; }
        public virtual ICollection<SessionGradingPeriod> SessionGradingPeriods { get; set; }
        public virtual ICollection<StudentSchoolAttendanceEvent> StudentSchoolAttendanceEvents { get; set; }
    }
}
