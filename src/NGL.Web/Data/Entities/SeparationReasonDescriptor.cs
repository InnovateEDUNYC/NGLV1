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
    
    public partial class SeparationReasonDescriptor
    {
        public SeparationReasonDescriptor()
        {
            this.StaffEducationOrganizationEmploymentAssociations = new HashSet<StaffEducationOrganizationEmploymentAssociation>();
        }
    
        public int SeparationReasonDescriptorId { get; set; }
        public Nullable<int> SeparationReasonTypeId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual SeparationReasonType SeparationReasonType { get; set; }
        public virtual ICollection<StaffEducationOrganizationEmploymentAssociation> StaffEducationOrganizationEmploymentAssociations { get; set; }
    }
}
