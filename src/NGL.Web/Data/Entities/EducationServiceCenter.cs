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
    
    public partial class EducationServiceCenter
    {
        public EducationServiceCenter()
        {
            this.LocalEducationAgencies = new HashSet<LocalEducationAgency>();
        }
    
        public int EducationServiceCenterId { get; set; }
        public Nullable<int> StateEducationAgencyId { get; set; }
    
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual StateEducationAgency StateEducationAgency { get; set; }
        public virtual ICollection<LocalEducationAgency> LocalEducationAgencies { get; set; }
    }
}
