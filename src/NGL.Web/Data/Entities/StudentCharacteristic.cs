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
    
    public partial class StudentCharacteristic
    {
        public StudentCharacteristic()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int StudentUSI { get; set; }
        public int StudentCharacteristicDescriptorId { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string DesignatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int StudentCharacteristicIdentity { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual StudentCharacteristicDescriptor StudentCharacteristicDescriptor { get; set; }
    }
}
