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
    
    public partial class Staff
    {
        public Staff()
        {
            this.ContractedStaffs = new HashSet<ContractedStaff>();
            this.DisciplineActionStaffs = new HashSet<DisciplineActionStaff>();
            this.DisciplineIncidents = new HashSet<DisciplineIncident>();
            this.InterventionStaffs = new HashSet<InterventionStaff>();
            this.LeaveEvents = new HashSet<LeaveEvent>();
            this.Payrolls = new HashSet<Payroll>();
            this.SectionAttendanceTakenEvents = new HashSet<SectionAttendanceTakenEvent>();
            this.StaffAddresses = new HashSet<StaffAddress>();
            this.StaffCohortAssociations = new HashSet<StaffCohortAssociation>();
            this.StaffCredentials = new HashSet<StaffCredential>();
            this.StaffEducationOrganizationEmploymentAssociations = new HashSet<StaffEducationOrganizationEmploymentAssociation>();
            this.StaffEducationOrganizationAssignmentAssociations = new HashSet<StaffEducationOrganizationAssignmentAssociation>();
            this.StaffElectronicMails = new HashSet<StaffElectronicMail>();
            this.StaffIdentificationCodes = new HashSet<StaffIdentificationCode>();
            this.StaffIdentificationDocuments = new HashSet<StaffIdentificationDocument>();
            this.StaffInternationalAddresses = new HashSet<StaffInternationalAddress>();
            this.StaffLanguages = new HashSet<StaffLanguage>();
            this.StaffOtherNames = new HashSet<StaffOtherName>();
            this.StaffProgramAssociations = new HashSet<StaffProgramAssociation>();
            this.StaffRaces = new HashSet<StaffRace>();
            this.StaffSchoolAssociations = new HashSet<StaffSchoolAssociation>();
            this.StaffSectionAssociations = new HashSet<StaffSectionAssociation>();
            this.StaffTelephones = new HashSet<StaffTelephone>();
            this.StaffVisas = new HashSet<StaffVisa>();
            this.StudentSpecialEducationProgramAssociationServiceProviders = new HashSet<StudentSpecialEducationProgramAssociationServiceProvider>();
        }
    
        public int StaffUSI { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastSurname { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string MaidenName { get; set; }
        public Nullable<int> SexTypeId { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Nullable<int> OldEthnicityTypeId { get; set; }
        public Nullable<int> HighestCompletedLevelOfEducationDescriptorId { get; set; }
        public Nullable<int> YearsOfPriorProfessionalExperience { get; set; }
        public Nullable<int> YearsOfPriorTeachingExperience { get; set; }
        public Nullable<bool> HighlyQualifiedTeacher { get; set; }
        public Nullable<int> TeacherUSI { get; set; }
        public string LoginId { get; set; }
        public Nullable<int> CitizenshipStatusTypeId { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual CitizenshipStatusType CitizenshipStatusType { get; set; }
        public virtual ICollection<ContractedStaff> ContractedStaffs { get; set; }
        public virtual ICollection<DisciplineActionStaff> DisciplineActionStaffs { get; set; }
        public virtual ICollection<DisciplineIncident> DisciplineIncidents { get; set; }
        public virtual ICollection<InterventionStaff> InterventionStaffs { get; set; }
        public virtual ICollection<LeaveEvent> LeaveEvents { get; set; }
        public virtual LevelOfEducationDescriptor LevelOfEducationDescriptor { get; set; }
        public virtual OldEthnicityType OldEthnicityType { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<SectionAttendanceTakenEvent> SectionAttendanceTakenEvents { get; set; }
        public virtual SexType SexType { get; set; }
        public virtual ICollection<StaffAddress> StaffAddresses { get; set; }
        public virtual ICollection<StaffCohortAssociation> StaffCohortAssociations { get; set; }
        public virtual ICollection<StaffCredential> StaffCredentials { get; set; }
        public virtual ICollection<StaffEducationOrganizationEmploymentAssociation> StaffEducationOrganizationEmploymentAssociations { get; set; }
        public virtual ICollection<StaffEducationOrganizationAssignmentAssociation> StaffEducationOrganizationAssignmentAssociations { get; set; }
        public virtual ICollection<StaffElectronicMail> StaffElectronicMails { get; set; }
        public virtual ICollection<StaffIdentificationCode> StaffIdentificationCodes { get; set; }
        public virtual ICollection<StaffIdentificationDocument> StaffIdentificationDocuments { get; set; }
        public virtual ICollection<StaffInternationalAddress> StaffInternationalAddresses { get; set; }
        public virtual ICollection<StaffLanguage> StaffLanguages { get; set; }
        public virtual ICollection<StaffOtherName> StaffOtherNames { get; set; }
        public virtual ICollection<StaffProgramAssociation> StaffProgramAssociations { get; set; }
        public virtual ICollection<StaffRace> StaffRaces { get; set; }
        public virtual ICollection<StaffSchoolAssociation> StaffSchoolAssociations { get; set; }
        public virtual ICollection<StaffSectionAssociation> StaffSectionAssociations { get; set; }
        public virtual ICollection<StaffTelephone> StaffTelephones { get; set; }
        public virtual ICollection<StaffVisa> StaffVisas { get; set; }
        public virtual ICollection<StudentSpecialEducationProgramAssociationServiceProvider> StudentSpecialEducationProgramAssociationServiceProviders { get; set; }
    }
}