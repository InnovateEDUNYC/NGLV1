using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class ParentEnrollmentInfoModelToParentMapperTest
    {
        [Fact]
        public void ShouldMap()
        {
            var mapper = new ParentEnrollmentInfoModelToParentMapper();
            var parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                FirstName = "Cameron",
                LastName = "James",
                SexTypeEnum = SexTypeEnum.Male,
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
    }
}