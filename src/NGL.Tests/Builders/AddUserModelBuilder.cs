using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;

namespace NGL.Tests.Builders
{
    public class AddUserModelBuilder
    {
        private string Username = "asmith";
        private string Password = "secret";
        private string ConfirmPassword = "secret";
        private ApplicationRole Role = ApplicationRole.Admin;
        private string FirstName = "Adam";
        private string LastName = "Smith";
        private string PersonalEmail = "asmith@school.com";
        private string PersonalTitlePrefix = "Dr";
        private int StaffUSI = 1;
        private int TeacherUSI = 2;
        private bool HispanicLatino = true;
        private OldEthnicityTypeEnum OldEthnicityType = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative;
        private string GenerationCodeSuffix = "Jr";
        private string MaidenName = "";
        private SexTypeEnum? Sex = SexTypeEnum.Male;
        private DateTime? BirthDate = new DateTime(1987, 11, 29);
        private LevelOfEducationDescriptorEnum? HighestCompletedLevelOfEducation = LevelOfEducationDescriptorEnum.Bachelors;
        private int? YearsOfPriorProfessionalExperience = 10;
        private int? YearsOfPriorTeachingExperience = 5;
        private bool? HighlyQualified = true;
        private CitizenshipStatusTypeEnum? CitizenshipStatus = CitizenshipStatusTypeEnum.PermanentResident;
        private string SSN = "123-45-6789";
        private string Certificate1 = "certificate 1";
        private string Certificate2 = "certificate 2";
        private string Certificate3 = "certificate 3";
        private string Certificate4 = "certificate 4";
        private bool CriminalBackgroundCheck = true;
        private bool Fingerprinted = true;

        public AddUserModel Build()
        {
            return new AddUserModel
            {
                Username = Username,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Role = Role,
                FirstName = FirstName,
                LastName = LastName,
                PersonalEmail = PersonalEmail,
                PeronalTitlePrefix = PersonalTitlePrefix,
                StaffUSI = StaffUSI,
                TeacherUSI = TeacherUSI,
                HispanicLatino = HispanicLatino,
                OldEthnicityType = OldEthnicityType,
                GenerationCodeSuffix = GenerationCodeSuffix,
                MaidenName = MaidenName,
                Sex = Sex,
                BirthDate = BirthDate,
                HighestCompletedLevelOfEducation = HighestCompletedLevelOfEducation,
                YearsOfPriorProfessionalExperience = YearsOfPriorProfessionalExperience,
                YearsOfPriorTeachingExperience = YearsOfPriorTeachingExperience,
                HighlyQualified = HighlyQualified,
                CitizenshipStatus = CitizenshipStatus,
                SSN = SSN,
                Certificate1 = Certificate1,
                Certificate2 = Certificate2,
                Certificate3 = Certificate3,
                Certificate4 = Certificate4,
                CriminalBackgroundCheck = CriminalBackgroundCheck,
                Fingerprinted = Fingerprinted
            };
        }

        public AddUserModelBuilder WithStaffUSI(int staffUSI)
        {
            StaffUSI = staffUSI;
            return this;
        }
    }
}
