using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;
using Shouldly;
using Xunit;

namespace NGL.Tests.Account
{
    public class AddUserModelToStaffMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var model = new AddUserModelBuilder().Build();
            var staff = new AddUserModelToStaffMapper().Build(model);

            staff.LoginId.ShouldBe(model.Username);
            staff.FirstName.ShouldBe(model.FirstName);
            staff.LastSurname.ShouldBe(model.LastName);
            staff.PersonalTitlePrefix.ShouldBe(model.PeronalTitlePrefix);
            staff.StaffUSI.ShouldBe(model.StaffUSI.Value);
            staff.TeacherUSI.ShouldBe(model.TeacherUSI.Value);
            staff.HispanicLatinoEthnicity.ShouldBe(model.HispanicLatino);
            staff.GenerationCodeSuffix.ShouldBe(model.GenerationCodeSuffix);
            staff.MaidenName.ShouldBe(model.MaidenName);
            staff.SexTypeId.ShouldBe((int)model.Sex);
            staff.BirthDate.ShouldBe(model.BirthDate);
            staff.HighestCompletedLevelOfEducationDescriptorId.ShouldBe((int)model.HighestCompletedLevelOfEducation);
            staff.YearsOfPriorProfessionalExperience.ShouldBe(model.YearsOfPriorProfessionalExperience);
            staff.YearsOfPriorTeachingExperience.ShouldBe(model.YearsOfPriorTeachingExperience);
            staff.HighlyQualifiedTeacher.ShouldBe(model.HighlyQualified);
            staff.CitizenshipStatusTypeId.ShouldBe((int)model.CitizenshipStatus);

            staff.StaffIdentificationCodes.Single(code => code.StaffIdentificationSystemTypeId == (int)StaffIdentificationSystemTypeEnum.SSN).IdentificationCode.ShouldBe(model.SSN);
            staff.StaffCertificates.Single(certificate => certificate.Number == 1).Name.ShouldBe(model.Certificate1);
            staff.StaffCertificates.Single(certificate => certificate.Number == 2).Name.ShouldBe(model.Certificate2);
            staff.StaffCertificates.Single(certificate => certificate.Number == 3).Name.ShouldBe(model.Certificate3);
            staff.StaffCertificates.Single(certificate => certificate.Number == 4).Name.ShouldBe(model.Certificate4);
        }
    }
}
