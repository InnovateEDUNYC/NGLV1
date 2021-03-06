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
    
    public partial class StudentAssessmentAccommodation
    {
        public StudentAssessmentAccommodation()
        {
    		this.CreateDate = System.DateTime.Now;
        }
    
        public int StudentUSI { get; set; }
        public string AssessmentTitle { get; set; }
        public int AcademicSubjectDescriptorId { get; set; }
        public int AssessedGradeLevelDescriptorId { get; set; }
        public int Version { get; set; }
        public System.DateTime AdministrationDate { get; set; }
        public int AccommodationDescriptorId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int StudentAssessmentAccommodationIdentity { get; set; }
    
        public virtual AccommodationDescriptor AccommodationDescriptor { get; set; }
        public virtual StudentAssessment StudentAssessment { get; set; }
    }
}
