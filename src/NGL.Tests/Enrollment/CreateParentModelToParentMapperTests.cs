using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateParentModelToParentMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var mapper = new CreateParentModelToParentMapper();
            var parentEnrollmentInfoModel = new CreateParentModelBuilder().WithEmailAddress().Build();

            var parent = mapper.Build(parentEnrollmentInfoModel);

            parent.FirstName.ShouldBe(parentEnrollmentInfoModel.FirstName);
            parent.LastSurname.ShouldBe(parentEnrollmentInfoModel.LastName);
            parent.SexTypeId.ShouldBe((int)parentEnrollmentInfoModel.Sex.GetValueOrDefault());
            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumber.ShouldBe(parentEnrollmentInfoModel.TelephoneNumber);
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            var parentEmail = parent.ParentElectronicMails.First();
            parentEmail.ElectronicMailAddress.ShouldBe(parentEnrollmentInfoModel.EmailAddress);
            parentEmail.ElectronicMailTypeId.ShouldBe((int) ElectronicMailTypeEnum.HomePersonal);
        }

        [Fact]
        public void ShouldMapWithoutEmail()
        {
            var mapper = new CreateParentModelToParentMapper();
            var parentModelBuilder = new CreateParentModelBuilder();

            var parentEnrollmentInfoModel = parentModelBuilder.Build();

            var parent = mapper.Build(parentEnrollmentInfoModel);

            parent.FirstName.ShouldBe(parentEnrollmentInfoModel.FirstName);
            parent.LastSurname.ShouldBe(parentEnrollmentInfoModel.LastName);
            parent.SexTypeId.ShouldBe((int)parentEnrollmentInfoModel.Sex.GetValueOrDefault());
            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumber.ShouldBe(parentEnrollmentInfoModel.TelephoneNumber);
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            parent.ParentElectronicMails.ShouldBeEmpty();
        }
    }
}