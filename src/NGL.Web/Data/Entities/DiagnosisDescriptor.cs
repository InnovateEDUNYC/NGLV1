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
    
    public partial class DiagnosisDescriptor
    {
        public DiagnosisDescriptor()
        {
            this.InterventionDiagnosis = new HashSet<InterventionDiagnosi>();
            this.InterventionPrescriptionDiagnosis = new HashSet<InterventionPrescriptionDiagnosi>();
            this.InterventionStudyInterventionEffectivenesses = new HashSet<InterventionStudyInterventionEffectiveness>();
            this.StudentInterventionAssociationInterventionEffectivenesses = new HashSet<StudentInterventionAssociationInterventionEffectiveness>();
        }
    
        public int DiagnosisDescriptorId { get; set; }
        public Nullable<int> DiagnosisTypeId { get; set; }
    
        public virtual Descriptor Descriptor { get; set; }
        public virtual DiagnosisType DiagnosisType { get; set; }
        public virtual ICollection<InterventionDiagnosi> InterventionDiagnosis { get; set; }
        public virtual ICollection<InterventionPrescriptionDiagnosi> InterventionPrescriptionDiagnosis { get; set; }
        public virtual ICollection<InterventionStudyInterventionEffectiveness> InterventionStudyInterventionEffectivenesses { get; set; }
        public virtual ICollection<StudentInterventionAssociationInterventionEffectiveness> StudentInterventionAssociationInterventionEffectivenesses { get; set; }
    }
}
