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
    
    public partial class AchievementCategoryDescriptor
    {
        public AchievementCategoryDescriptor()
        {
            this.StudentAcademicRecordAcademicHonors = new HashSet<StudentAcademicRecordAcademicHonor>();
            this.StudentAcademicRecordDiplomas = new HashSet<StudentAcademicRecordDiploma>();
            this.StudentAcademicRecordRecognitions = new HashSet<StudentAcademicRecordRecognition>();
        }
    
        public int AchievementCategoryDescriptorId { get; set; }
        public Nullable<int> AchievementCategoryTypeId { get; set; }
    
        public virtual AchievementCategoryType AchievementCategoryType { get; set; }
        public virtual Descriptor Descriptor { get; set; }
        public virtual ICollection<StudentAcademicRecordAcademicHonor> StudentAcademicRecordAcademicHonors { get; set; }
        public virtual ICollection<StudentAcademicRecordDiploma> StudentAcademicRecordDiplomas { get; set; }
        public virtual ICollection<StudentAcademicRecordRecognition> StudentAcademicRecordRecognitions { get; set; }
    }
}
