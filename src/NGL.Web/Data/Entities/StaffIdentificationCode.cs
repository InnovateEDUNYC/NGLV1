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
    
    public partial class StaffIdentificationCode
    {
        public int StaffUSI { get; set; }
        public int StaffIdentificationSystemTypeId { get; set; }
        public string AssigningOrganizationIdentificationCode { get; set; }
        public string IdentificationCode { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual StaffIdentificationSystemType StaffIdentificationSystemType { get; set; }
    }
}
