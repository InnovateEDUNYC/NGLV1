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
    
    public partial class CountryType
    {
        public CountryType()
        {
            this.EducationOrganizationInternationalAddresses = new HashSet<EducationOrganizationInternationalAddress>();
            this.ParentIdentificationDocuments = new HashSet<ParentIdentificationDocument>();
            this.ParentInternationalAddresses = new HashSet<ParentInternationalAddress>();
            this.StaffIdentificationDocuments = new HashSet<StaffIdentificationDocument>();
            this.StaffInternationalAddresses = new HashSet<StaffInternationalAddress>();
            this.StudentIdentificationDocuments = new HashSet<StudentIdentificationDocument>();
            this.StudentInternationalAddresses = new HashSet<StudentInternationalAddress>();
        }
    
        public int CountryTypeId { get; set; }
        public string CodeValue { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<EducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses { get; set; }
        public virtual ICollection<ParentIdentificationDocument> ParentIdentificationDocuments { get; set; }
        public virtual ICollection<ParentInternationalAddress> ParentInternationalAddresses { get; set; }
        public virtual ICollection<StaffIdentificationDocument> StaffIdentificationDocuments { get; set; }
        public virtual ICollection<StaffInternationalAddress> StaffInternationalAddresses { get; set; }
        public virtual ICollection<StudentIdentificationDocument> StudentIdentificationDocuments { get; set; }
        public virtual ICollection<StudentInternationalAddress> StudentInternationalAddresses { get; set; }
    }
}
