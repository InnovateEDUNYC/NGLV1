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
    
    public partial class SpecialEducationSettingDescriptor
    {
        public SpecialEducationSettingDescriptor()
        {
            this.StudentSpecialEducationProgramAssociations = new HashSet<StudentSpecialEducationProgramAssociation>();
        }
    
        public int SpecialEducationSettingDescriptorId { get; set; }
        public Nullable<int> SpecialEducationSettingTypeId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual SpecialEducationSettingType SpecialEducationSettingType { get; set; }
        public virtual ICollection<StudentSpecialEducationProgramAssociation> StudentSpecialEducationProgramAssociations { get; set; }
    }
}
