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
    
    public partial class LimitedEnglishProficiencyDescriptor
    {
        public LimitedEnglishProficiencyDescriptor()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int LimitedEnglishProficiencyDescriptorId { get; set; }
        public int LimitedEnglishProficiencyTypeId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual LimitedEnglishProficiencyType LimitedEnglishProficiencyType { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}