using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class EditProfileParentModelToParentMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var entity = new ParentBuilder().WithEmail().WithPhoneNumber().Build();
            entity.StudentParentAssociations.Add(new StudentParentAssociation());
            var model = new EditProfileParentModelBuilder().Build();
            var mapper = new EditProfileParentModelToParentMapper(new EditableParentAddressModelToParentMapper());

            mapper.Map(model, entity);

            entity.FirstName.ShouldBe(model.FirstName);
            entity.LastSurname.ShouldBe(model.LastName);
            entity.ParentElectronicMails.First().ElectronicMailAddress.ShouldBe(model.EmailAddress);
            entity.ParentElectronicMails.First().ElectronicMailTypeId.ShouldBe((int)ElectronicMailTypeEnum.HomePersonal);
            entity.ParentTelephones.First().TelephoneNumber.ShouldBe(model.TelephoneNumber);
            entity.ParentTelephones.First().TelephoneNumberTypeId.ShouldBe((int) TelephoneNumberTypeEnum.Emergency1);
            entity.SexTypeId.ShouldBe((int) model.Sex);
        }

        [Fact]
        public void ShouldMapWhenParentAddressWasSameAsStudent()
        {
            var entity = new ParentBuilder().WithEmail().WithPhoneNumber().Build();
            entity.StudentParentAssociations.Add(new StudentParentAssociation{LivesWith = true});
            var model = new EditProfileParentModelBuilder().Build();
            var mapper = new EditProfileParentModelToParentMapper(new EditableParentAddressModelToParentMapper());

            mapper.Map(model, entity);

            entity.FirstName.ShouldBe(model.FirstName);
            entity.LastSurname.ShouldBe(model.LastName);
            entity.ParentElectronicMails.First().ElectronicMailAddress.ShouldBe(model.EmailAddress);
            entity.ParentElectronicMails.First().ElectronicMailTypeId.ShouldBe((int)ElectronicMailTypeEnum.HomePersonal);
            entity.ParentTelephones.First().TelephoneNumber.ShouldBe(model.TelephoneNumber);
            entity.ParentTelephones.First().TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            entity.SexTypeId.ShouldBe((int)model.Sex);
            entity.StudentParentAssociations.First().LivesWith.ShouldBe(model.SameAddressAsStudent);
        }

        [Fact]
        public void ShouldCreateEmailIfNoEmailExisted()
        {
            var entity = new ParentBuilder().WithPhoneNumber().Build();
            entity.StudentParentAssociations.Add(new StudentParentAssociation());
            var model = new EditProfileParentModelBuilder().Build();
            var mapper = new EditProfileParentModelToParentMapper(new EditableParentAddressModelToParentMapper());

            mapper.Map(model, entity);

            entity.FirstName.ShouldBe(model.FirstName);
            entity.LastSurname.ShouldBe(model.LastName);
            entity.ParentElectronicMails.First().ElectronicMailAddress.ShouldBe(model.EmailAddress);
            entity.ParentElectronicMails.First().ElectronicMailTypeId.ShouldBe((int)ElectronicMailTypeEnum.HomePersonal);
            entity.ParentTelephones.First().TelephoneNumber.ShouldBe(model.TelephoneNumber);
            entity.ParentTelephones.First().TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            entity.SexTypeId.ShouldBe((int)model.Sex);
        }

        [Fact]
        public void ShouldNotCreateEmailIfNoEmailExistedButBlankEmailInEditProfileModel()
        {
            var entity = new ParentBuilder().WithPhoneNumber().Build();
            entity.StudentParentAssociations.Add(new StudentParentAssociation());
            var model = new EditProfileParentModelBuilder().WithBlankEmail().Build();
            var mapper = new EditProfileParentModelToParentMapper(new EditableParentAddressModelToParentMapper());

            mapper.Map(model, entity);

            entity.FirstName.ShouldBe(model.FirstName);
            entity.LastSurname.ShouldBe(model.LastName);
            entity.ParentElectronicMails.ShouldBeEmpty();
            entity.ParentTelephones.First().TelephoneNumber.ShouldBe(model.TelephoneNumber);
            entity.ParentTelephones.First().TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            entity.SexTypeId.ShouldBe((int)model.Sex);
        }
    }
}
