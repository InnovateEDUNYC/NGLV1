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
    
    public partial class SchoolFoodServicesEligibilityType
    {
        public SchoolFoodServicesEligibilityType()
        {
            this.SchoolFoodServicesEligibilityDescriptors = new HashSet<SchoolFoodServicesEligibilityDescriptor>();
        }
    
        public int SchoolFoodServicesEligibilityTypeId { get; set; }
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<SchoolFoodServicesEligibilityDescriptor> SchoolFoodServicesEligibilityDescriptors { get; set; }
    }
}
