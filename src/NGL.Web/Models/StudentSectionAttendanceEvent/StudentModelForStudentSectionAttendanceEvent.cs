using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.StudentSectionAttendanceEvent
{
    public class StudentModelForStudentSectionAttendanceEvent
    {
        public int StudentUSI { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastSurname { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string MaidenName { get; set; }
        public int SexTypeId { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string CityOfBirth { get; set; }
        public string ProfileThumbnail { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public string DisplacementStatus { get; set; }
        public string InternationalProvinceOfBirth { get; set; }
        public virtual ICollection<StudentSchoolAttendanceEvent> StudentSchoolAttendanceEvents { get; set; }
        public virtual ICollection<StudentSectionAssociation> StudentSectionAssociations { get; set; }
        public virtual ICollection<StudentSectionAttendanceEventModel> StudentSectionAttendanceEvents { get; set; }
    }
}