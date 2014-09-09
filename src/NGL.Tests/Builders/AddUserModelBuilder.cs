using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;

namespace NGL.Tests.Builders
{
    public class AddUserModelBuilder
    {
        private const string Username = "asmith";
        private const string Password = "secret";
        private const string ConfirmPassword = "secret";
        private const ApplicationRole Role = ApplicationRole.Admin;
        private const string FirstName = "Adam";
        private const string LastName = "Smith";
        private const string PersonalEmail = "asmith@school.com";
        private const string PersonalTitlePrefix = "Dr";
        private static int _staffUsi = 1;
        private const int TeacherUsi = 2;
        private const bool HispanicLatino = true;
        private const OldEthnicityTypeEnum OldEthnicityType = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative;
        private const string GenerationCodeSuffix = "Jr";
        private const string MaidenName = "";
        private readonly SexTypeEnum? _sex = SexTypeEnum.Male;
        private readonly DateTime? _birthDate = new DateTime(1987, 11, 29);
        private readonly LevelOfEducationDescriptorEnum? _highestCompletedLevelOfEducation = LevelOfEducationDescriptorEnum.Bachelors;
        private static readonly int? YearsOfPriorProfessionalExperience = 10;
        private static readonly int? YearsOfPriorTeachingExperience = 5;
        private static readonly bool? HighlyQualified = true;
        private readonly CitizenshipStatusTypeEnum? _citizenshipStatus = CitizenshipStatusTypeEnum.PermanentResident;
        private const string Ssn = "123-45-6789";
        private const string Certificate1 = "certificate 1";
        private const string Certificate2 = "certificate 2";
        private const bool CriminalBackgroundCheck = true;
        private const bool Fingerprinted = true;

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
                PersonalTitlePrefix = PersonalTitlePrefix,
                StaffUSI = _staffUsi,
                TeacherUSI = TeacherUsi,
                HispanicLatino = HispanicLatino,
                OldEthnicityType = OldEthnicityType,
                GenerationCodeSuffix = GenerationCodeSuffix,
                MaidenName = MaidenName,
                Sex = _sex,
                BirthDate = _birthDate,
                HighestCompletedLevelOfEducation = _highestCompletedLevelOfEducation,
                YearsOfPriorProfessionalExperience = YearsOfPriorProfessionalExperience,
                YearsOfPriorTeachingExperience = YearsOfPriorTeachingExperience,
                HighlyQualified = HighlyQualified,
                CitizenshipStatus = _citizenshipStatus,
                SSN = Ssn,
                Certificate1 = Certificate1,
                Certificate2 = Certificate2,
                CriminalBackgroundCheck = CriminalBackgroundCheck,
                Fingerprinted = Fingerprinted
            };
        }

        public AddUserModelBuilder WithStaffUsi(int staffUsi)
        {
            _staffUsi = staffUsi;
            return this;
        }
    }
}
