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
    
    public partial class StudentProgramAssociation
    {
        public StudentProgramAssociation()
        {
            this.StudentCompetencyObjectives = new HashSet<StudentCompetencyObjective>();
            this.StudentLearningObjectives = new HashSet<StudentLearningObjective>();
            this.StudentProgramAssociationServices = new HashSet<StudentProgramAssociationService>();
        }
    
        public int StudentUSI { get; set; }
        public int ProgramTypeId { get; set; }
        public string ProgramName { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> ReasonExitedDescriptorId { get; set; }
        public Nullable<bool> ServedOutsideOfRegularSession { get; set; }
        public int EducationOrganizationId { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual Program Program { get; set; }
        public virtual ReasonExitedDescriptor ReasonExitedDescriptor { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<StudentCompetencyObjective> StudentCompetencyObjectives { get; set; }
        public virtual StudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }
        public virtual ICollection<StudentLearningObjective> StudentLearningObjectives { get; set; }
        public virtual StudentMigrantEducationProgramAssociation StudentMigrantEducationProgramAssociation { get; set; }
        public virtual ICollection<StudentProgramAssociationService> StudentProgramAssociationServices { get; set; }
        public virtual StudentSpecialEducationProgramAssociation StudentSpecialEducationProgramAssociation { get; set; }
        public virtual TitleIPartAParticipantType TitleIPartAParticipantType { get; set; }
    }
}
