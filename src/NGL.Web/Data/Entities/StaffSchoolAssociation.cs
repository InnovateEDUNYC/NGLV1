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
    
    public partial class StaffSchoolAssociation
    {
        public StaffSchoolAssociation()
        {
    		this.Id = System.Guid.NewGuid();
    		this.LastModifiedDate = System.DateTime.Now;
    		this.CreateDate = System.DateTime.Now;
            this.StaffSchoolAssociationAcademicSubjects = new HashSet<StaffSchoolAssociationAcademicSubject>();
            this.StaffSchoolAssociationGradeLevels = new HashSet<StaffSchoolAssociationGradeLevel>();
        }
    
        public int StaffUSI { get; set; }
        public int ProgramAssignmentDescriptorId { get; set; }
        public int SchoolId { get; set; }
        public Nullable<short> SchoolYear { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int StaffSchoolAssociationIdentity { get; set; }
    
        public virtual ProgramAssignmentDescriptor ProgramAssignmentDescriptor { get; set; }
        public virtual School School { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<StaffSchoolAssociationAcademicSubject> StaffSchoolAssociationAcademicSubjects { get; set; }
        public virtual ICollection<StaffSchoolAssociationGradeLevel> StaffSchoolAssociationGradeLevels { get; set; }
    }
}
