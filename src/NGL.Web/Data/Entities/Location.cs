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
    
    public partial class Location
    {
        public Location()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.Sections = new HashSet<Section>();
        }
    
        public int SchoolId { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public Nullable<int> MaximumNumberOfSeats { get; set; }
        public Nullable<int> OptimalNumberOfSeats { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int LocationIdentity { get; set; }
    
        public virtual School School { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
