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
    
    public partial class ClassPeriod
    {
        public ClassPeriod()
        {
            this.BellScheduleMeetingTimes = new HashSet<BellScheduleMeetingTime>();
            this.InterventionMeetingTimes = new HashSet<InterventionMeetingTime>();
            this.Sections = new HashSet<Section>();
        }
    
        public int SchoolId { get; set; }
        public string ClassPeriodName { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<BellScheduleMeetingTime> BellScheduleMeetingTimes { get; set; }
        public virtual ICollection<InterventionMeetingTime> InterventionMeetingTimes { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
