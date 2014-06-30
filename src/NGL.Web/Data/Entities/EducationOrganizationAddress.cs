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
    
    public partial class EducationOrganizationAddress
    {
        public int EducationOrganizationId { get; set; }
        public int AddressTypeId { get; set; }
        public string StreetNumberName { get; set; }
        public string ApartmentRoomSuiteNumber { get; set; }
        public string BuildingSiteNumber { get; set; }
        public string City { get; set; }
        public int StateAbbreviationTypeId { get; set; }
        public string PostalCode { get; set; }
        public string NameOfCounty { get; set; }
        public string CountyFIPSCode { get; set; }
        public Nullable<int> CountryCodeTypeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual AddressType AddressType { get; set; }
        public virtual CountryCodeType CountryCodeType { get; set; }
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual StateAbbreviationType StateAbbreviationType { get; set; }
    }
}
