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
    
    public partial class BellSchedule
    {
        public BellSchedule()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.BellScheduleMeetingTimes = new HashSet<BellScheduleMeetingTime>();
        }
    
        public int SchoolId { get; set; }
        public int GradeLevelDescriptorId { get; set; }
        public System.DateTime Date { get; set; }
        public string BellScheduleName { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int BellScheduleIdentity { get; set; }
    
        public virtual CalendarDate CalendarDate { get; set; }
        public virtual GradeLevelDescriptor GradeLevelDescriptor { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<BellScheduleMeetingTime> BellScheduleMeetingTimes { get; set; }
    }
}
