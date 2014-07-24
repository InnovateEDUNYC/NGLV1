﻿using System.Linq;
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
            var parentEnrollmentInfoModel = new CreateParentModel
            {
                FirstName = "Cameron",
                LastName = "James",
                Sex = SexTypeEnum.Male,
                TelephoneNumber = "933-2378",
                EmailAddress = "some@body.org",
            };

            var parent = new Parent();
            
            mapper.Map(parentEnrollmentInfoModel, parent);

            parent.FirstName.ShouldBe("Cameron");
            parent.LastSurname.ShouldBe("James");
            parent.SexTypeId.ShouldBe((int) SexTypeEnum.Male);
            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumber.ShouldBe("933-2378");
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int) TelephoneNumberTypeEnum.Emergency1);
            var parentEmail = parent.ParentElectronicMails.First();
            parentEmail.ElectronicMailAddress.ShouldBe("some@body.org");
            parentEmail.ElectronicMailTypeId.ShouldBe((int) ElectronicMailTypeEnum.HomePersonal);
        }

        [Fact]
        public void ShouldMapWithoutEmail()
        {
            var mapper = new CreateParentModelToParentMapper();
            var parentEnrollmentInfoModel = new CreateParentModel
            {
                FirstName = "Cameron",
                LastName = "James",
                Sex = SexTypeEnum.Male,
                TelephoneNumber = "933-2378"
            };

            var parent = new Parent();

            mapper.Map(parentEnrollmentInfoModel, parent);

            parent.FirstName.ShouldBe("Cameron");
            parent.LastSurname.ShouldBe("James");
            parent.SexTypeId.ShouldBe((int)SexTypeEnum.Male);
            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumber.ShouldBe("933-2378");
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int)TelephoneNumberTypeEnum.Emergency1);
            parent.ParentElectronicMails.ShouldBeEmpty();
        }
    }
}