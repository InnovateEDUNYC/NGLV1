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
    
    public partial class StudentIdentificationCode
    {
        public int StudentUSI { get; set; }
        public int StudentIdentificationSystemTypeId { get; set; }
        public string AssigningOrganizationIdentificationCode { get; set; }
        public string IdentificationCode { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual StudentIdentificationSystemType StudentIdentificationSystemType { get; set; }
    }
}
