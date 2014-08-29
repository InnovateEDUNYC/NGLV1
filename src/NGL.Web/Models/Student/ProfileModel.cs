using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Student
{
    public class ProfileModel
    {
        [Display(Name = "Student USI")]
        public int StudentUsi { get; set; }

        public NameModel StudentName { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public EditStudentBiographicalInfoModel BiographicalInfo { get; set; }
        public HomeAddressModel HomeAddress { get; set; }
        public EditProfileParentModel EditProfileParentModel { get; set; }
        public EditProfileParentModel SecondEditProfileParentModel { get; set; }
        public ProfileAcademicDetailModel AcademicDetail { get; set; }
        public ProfileProgramStatusModel ProgramStatus { get; set; }
        public int AttendancePercentage { get; set; }
        public int FlagCount { get; set; }
    }
}