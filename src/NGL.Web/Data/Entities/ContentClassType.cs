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
    
    public partial class ContentClassType
    {
        public ContentClassType()
        {
            this.EducationContents = new HashSet<EducationContent>();
        }
    
        public int ContentClassTypeId { get; set; }
        public string CodeValue { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<EducationContent> EducationContents { get; set; }
    }
}