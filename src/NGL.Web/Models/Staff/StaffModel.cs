using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Staff
{
    public class StaffModel
    {
        public int StaffUSI { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastSurname { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string MaidenName { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public int? TeacherUSI { get; set; }
        public string LoginId { get; set; }

        public virtual ICollection<StaffSectionAssociation> StaffSectionAssociations { get; set; }
    }
}