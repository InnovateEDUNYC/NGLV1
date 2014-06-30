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
    
    public partial class LearningStandardContentStandard
    {
        public LearningStandardContentStandard()
        {
            this.LearningStandardContentStandardAuthors = new HashSet<LearningStandardContentStandardAuthor>();
        }
    
        public string LearningStandardId { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string URI { get; set; }
        public Nullable<System.DateTime> PublicationDate { get; set; }
        public Nullable<short> PublicationYear { get; set; }
        public Nullable<int> PublicationStatusTypeId { get; set; }
        public Nullable<int> MandatingEducationOrganizationId { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual EducationOrganization EducationOrganization { get; set; }
        public virtual LearningStandard LearningStandard { get; set; }
        public virtual PublicationStatusType PublicationStatusType { get; set; }
        public virtual ICollection<LearningStandardContentStandardAuthor> LearningStandardContentStandardAuthors { get; set; }
    }
}