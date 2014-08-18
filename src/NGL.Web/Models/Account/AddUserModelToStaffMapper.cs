using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Account
{
    public class AddUserModelToStaffMapper: MapperBase<AddUserModel, Data.Entities.Staff>
    {
        public override void Map(AddUserModel source, Data.Entities.Staff target)
        {
            target.LoginId = source.Username;
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.LastSurname = source.LastName;
            target.PersonalTitlePrefix = source.PeronalTitlePrefix;
            target.StaffUSI = source.StaffUSI.GetValueOrDefault();
            target.TeacherUSI = source.TeacherUSI.GetValueOrDefault();
            target.HispanicLatinoEthnicity = source.HispanicLatino;
            target.OldEthnicityTypeId = (int?)source.OldEthnicityType;
            target.GenerationCodeSuffix = source.GenerationCodeSuffix;
            target.MaidenName = source.MaidenName;
            target.SexTypeId = (int?)source.Sex;
            target.BirthDate = source.BirthDate;
            target.HighestCompletedLevelOfEducationDescriptorId = (int?)source.HighestCompletedLevelOfEducation;
            target.YearsOfPriorProfessionalExperience = source.YearsOfPriorProfessionalExperience;
            target.YearsOfPriorTeachingExperience = source.YearsOfPriorTeachingExperience;
            target.HighlyQualifiedTeacher = source.HighlyQualified;
            target.CitizenshipStatusTypeId = (int?)source.CitizenshipStatus;

            var ssn = new StaffIdentificationCode
            {
                StaffIdentificationSystemTypeId = (int)StaffIdentificationSystemTypeEnum.SSN,
                IdentificationCode = source.SSN
            };
            target.StaffIdentificationCodes.Add(ssn);

            AddCertificate(1, source.Certificate1, target);
            AddCertificate(2, source.Certificate2, target);
            AddCertificate(3, source.Certificate3, target);
            AddCertificate(4, source.Certificate4, target);
        }

        private static void AddCertificate(int number, string name, Data.Entities.Staff target)
        {
            var certificate = new StaffCertificate
            {
                Number = number,
                Name = name,
            };
            target.StaffCertificates.Add(certificate);
        }
    }
}