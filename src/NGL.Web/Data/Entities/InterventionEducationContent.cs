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
    
    public partial class InterventionEducationContent
    {
        public InterventionEducationContent()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public string InterventionIdentificationCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ContentIdentifier { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual EducationContent EducationContent { get; set; }
        public virtual Intervention Intervention { get; set; }
    }
}
