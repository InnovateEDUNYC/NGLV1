using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class ParentEnrollmentInfoModelToStudentParentAssociationMapperTest
    {

        [Fact]
        public void ShouldBuildAssociationWithParentAddressWhenAddressIsDifferentFromStudent()
        {
            var mapper = new ParentEnrollmentInfoModelToStudentParentAssociationMapper(new ParentEnrollmentInfoModelToParentMapper(), new ParentEnrollmentInfoModelToParentAddressMapper());
            var parentEnrollmentInfoModel = MakeParentEnrollmentInfoModel(false);

            var studentParentAssociation = mapper.Build(parentEnrollmentInfoModel);
            
            studentParentAssociation.LivesWith.ShouldBe(false);
            var parent = studentParentAssociation.Parent;

            CheckBasicParentInfo(studentParentAssociation);

            var parentAddress = parent.ParentAddresses.First();
            parentAddress.City.ShouldBe("Durham");
            parentAddress.StateAbbreviationTypeId.ShouldBe((int)StateAbbreviationTypeEnum.NC);
            parentAddress.PostalCode.ShouldBe("70131");
            parentAddress.StreetNumberName.ShouldBe("1 Boak St");
            parentAddress.ApartmentRoomSuiteNumber.ShouldBe("1st flr");
        }

        [Fact]
        public void ShouldBuildAssociationWithoutParentAddressWhenParentLivesWithStudent()
        {
            var mapper = new ParentEnrollmentInfoModelToStudentParentAssociationMapper(new ParentEnrollmentInfoModelToParentMapper(), new ParentEnrollmentInfoModelToParentAddressMapper());
            var parentEnrollmentInfoModel = MakeParentEnrollmentInfoModel(true);

            var studentParentAssociation = mapper.Build(parentEnrollmentInfoModel);

            studentParentAssociation.LivesWith.ShouldBe(false);
            CheckBasicParentInfo(studentParentAssociation);
        }

        private void CheckBasicParentInfo(StudentParentAssociation studentParentAssociation)
        {
            var parent = studentParentAssociation.Parent;


            studentParentAssociation.RelationTypeId.ShouldBe((int)RelationTypeEnum.Mother);
            studentParentAssociation.PrimaryContactStatus.ShouldBe(true);

            parent.FirstName.ShouldBe("Mari");
            parent.LastSurname.ShouldBe("Chavez");
            parent.SexTypeId.ShouldBe((int) SexTypeEnum.Female);

            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int) TelephoneNumberTypeEnum.Emergency1);
            parentTelephone.TelephoneNumber.ShouldBe("555-5555");

            var parentEmail = parent.ParentElectronicMails.First();
            parentEmail.ElectronicMailAddress.ShouldBe("mari@mother.com");
            parentEmail.ElectronicMailTypeId.ShouldBe((int) ElectronicMailTypeEnum.HomePersonal);
        }

        private ParentEnrollmentInfoModel MakeParentEnrollmentInfoModel(bool hasSameAddress)
        {

            var model = new ParentEnrollmentInfoModel
            {

                FirstName = "Mari",
                LastName = "Chavez",
                RelationshipToStudent = RelationTypeEnum.Mother,
                Sex = SexTypeEnum.Female,
                MakeThisPrimaryContact = true,
                TelephoneNumber = "555-5555",
                EmailAddress = "mari@mother.com",
                SameAddressAsStudent = hasSameAddress
            };

            if (ParentDoesNotLiveWithStudent(hasSameAddress)) {
                model.City = "Durham";
                model.State = StateAbbreviationTypeEnum.NC;
                model.PostalCode = "70131";
                model.Address = "1 Boak St";
                model.Address2 = "1st flr";
            }
            return model;
        }

        private static bool ParentDoesNotLiveWithStudent(bool hasSameAddress)
        {
            return !hasSameAddress;
        }
    }
}
