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
    
    public partial class CourseLevelCharacteristic
    {
        public int EducationOrganizationId { get; set; }
        public string CourseCode { get; set; }
        public int CourseLevelCharacteristicTypeId { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual CourseLevelCharacteristicType CourseLevelCharacteristicType { get; set; }
    }
}