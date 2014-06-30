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
    
    public partial class ParentIdentificationDocument
    {
        public string DocumentTitle { get; set; }
        public int PersonalInformationVerificationTypeId { get; set; }
        public Nullable<System.DateTime> DocumentExpirationDate { get; set; }
        public string IssuerDocumentIdentificationCode { get; set; }
        public string IssuerName { get; set; }
        public int IdentificationDocumentUseTypeId { get; set; }
        public int ParentUSI { get; set; }
        public Nullable<int> IssuerCountryTypeId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual CountryType CountryType { get; set; }
        public virtual IdentificationDocumentUseType IdentificationDocumentUseType { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual PersonalInformationVerificationType PersonalInformationVerificationType { get; set; }
    }
}