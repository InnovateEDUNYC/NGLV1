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
    
    public partial class EducationContentLanguage
    {
        public EducationContentLanguage()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public string ContentIdentifier { get; set; }
        public int LanguageDescriptorId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual EducationContent EducationContent { get; set; }
        public virtual LanguageDescriptor LanguageDescriptor { get; set; }
    }
}
