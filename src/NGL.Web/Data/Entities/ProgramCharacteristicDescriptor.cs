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
    
    public partial class ProgramCharacteristicDescriptor
    {
        public ProgramCharacteristicDescriptor()
        {
            this.ProgramCharacteristics = new HashSet<ProgramCharacteristic>();
            this.StudentProgramParticipationProgramCharacteristics = new HashSet<StudentProgramParticipationProgramCharacteristic>();
        }
    
        public int ProgramCharacteristicDescriptorId { get; set; }
        public int ProgramCharacteristicTypeId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual ICollection<ProgramCharacteristic> ProgramCharacteristics { get; set; }
        public virtual ProgramCharacteristicType ProgramCharacteristicType { get; set; }
        public virtual ICollection<StudentProgramParticipationProgramCharacteristic> StudentProgramParticipationProgramCharacteristics { get; set; }
    }
}
