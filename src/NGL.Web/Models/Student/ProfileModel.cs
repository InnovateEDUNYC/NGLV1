using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Models.Student
{
    public class ProfileModel
    {
        [Display(Name = "Student USI")]
        public int StudentUsi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public StudentBiographicalInformationModel BiographicalInformation { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public ProfileParentModel ProfileParentModel { get; set; }
        public ProfileParentModel SecondProfileParentModel { get; set; }
        public ProfileAcademicDetailModel AcademicDetail { get; set; }
        public ProfileProgramStatusModel ProgramStatus { get; set; }
        public int AttendancePercentage { get; set; }
        public int FlagCount { get; set; }
    }
}