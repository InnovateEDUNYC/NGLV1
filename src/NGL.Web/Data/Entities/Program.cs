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
    
    public partial class Program
    {
        public Program()
        {
            this.AssessmentPrograms = new HashSet<AssessmentProgram>();
            this.CohortPrograms = new HashSet<CohortProgram>();
            this.ProgramCharacteristics = new HashSet<ProgramCharacteristic>();
            this.ProgramLearningStandards = new HashSet<ProgramLearningStandard>();
            this.ProgramLearningObjectives = new HashSet<ProgramLearningObjective>();
            this.ProgramServices = new HashSet<ProgramService>();
            this.RestraintEventPrograms = new HashSet<RestraintEventProgram>();
            this.SectionPrograms = new HashSet<SectionProgram>();
            this.StaffProgramAssociations = new HashSet<StaffProgramAssociation>();
            this.StudentProgramAssociations = new HashSet<StudentProgramAssociation>();
            this.StudentProgramAttendanceEvents = new HashSet<StudentProgramAttendanceEvent>();
        }
    
        public int EducationOrganizationId { get; set; }
        public int ProgramTypeId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramId { get; set; }
        public Nullable<int> ProgramSponsorTypeId { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<AssessmentProgram> AssessmentPrograms { get; set; }
        public virtual ICollection<CohortProgram> CohortPrograms { get; set; }
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual ProgramSponsorType ProgramSponsorType { get; set; }
        public virtual ProgramType ProgramType { get; set; }
        public virtual ICollection<ProgramCharacteristic> ProgramCharacteristics { get; set; }
        public virtual ICollection<ProgramLearningStandard> ProgramLearningStandards { get; set; }
        public virtual ICollection<ProgramLearningObjective> ProgramLearningObjectives { get; set; }
        public virtual ICollection<ProgramService> ProgramServices { get; set; }
        public virtual ICollection<RestraintEventProgram> RestraintEventPrograms { get; set; }
        public virtual ICollection<SectionProgram> SectionPrograms { get; set; }
        public virtual ICollection<StaffProgramAssociation> StaffProgramAssociations { get; set; }
        public virtual ICollection<StudentProgramAssociation> StudentProgramAssociations { get; set; }
        public virtual ICollection<StudentProgramAttendanceEvent> StudentProgramAttendanceEvents { get; set; }
    }
}