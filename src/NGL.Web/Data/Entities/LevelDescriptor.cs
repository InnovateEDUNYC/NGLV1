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
    
    public partial class LevelDescriptor
    {
        public LevelDescriptor()
        {
            this.LevelDescriptorGradeLevels = new HashSet<LevelDescriptorGradeLevel>();
            this.StaffCredentials = new HashSet<StaffCredential>();
        }
    
        public int LevelDescriptorId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual ICollection<LevelDescriptorGradeLevel> LevelDescriptorGradeLevels { get; set; }
        public virtual ICollection<StaffCredential> StaffCredentials { get; set; }
    }
}
