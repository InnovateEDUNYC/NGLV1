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
    
    public partial class ParentOtherName
    {
        public ParentOtherName()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int ParentUSI { get; set; }
        public int OtherNameTypeId { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastSurname { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ParentOtherNameIdentity { get; set; }
    
        public virtual OtherNameType OtherNameType { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
