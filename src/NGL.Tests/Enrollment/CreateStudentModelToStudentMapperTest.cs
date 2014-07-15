using System;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateStudentModelToStudentMapperTest
    {
        private CreateStudentModelToStudentMapper _mapper;
        private readonly Web.Data.Entities.Student _student = new Web.Data.Entities.Student();
        readonly CreateStudentModel _createStudentModel = new CreateStudentModel();
        private CreateParentModel _parentEnrollmentInfoModel;

        [Fact]
        public void ShouldMapCreateStudentModelToStudent()
        {
            SetUp();
            _mapper.Map(_createStudentModel, _student);

            const int languageDescriptorId = (int) LanguageDescriptorEnum.English;

            _student.FirstName.ShouldBe("John");
            _student.LastSurname.ShouldBe("Doe");
            _student.SexTypeId.ShouldBe((int) SexTypeEnum.Male);
            _student.BirthDate.ShouldBe(new DateTime(2001, 1, 1));
            _student.HispanicLatinoEthnicity.ShouldBe(false);
            _student.StudentLanguages.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);
            _student.StudentLanguages.First()
                .StudentLanguageUses.First()
                .LanguageUseTypeId.ShouldBe((int) LanguageUseTypeEnum.Homelanguage);
            _student.StudentLanguages.First()
                .StudentLanguageUses.First()
                .LanguageDescriptorId.ShouldBe(languageDescriptorId);

            var studentRace = _student.StudentRaces.First();
            studentRace.RaceTypeId.ShouldBe((int) RaceTypeEnum.AmericanIndianAlaskanNative);

            var studentAddress = _student.StudentAddresses.First();

            studentAddress.StreetNumberName.ShouldBe("1060 W Addison St");
            studentAddress.ApartmentRoomSuiteNumber.ShouldBe("33");
            studentAddress.PostalCode.ShouldBe("60657");
            studentAddress.StateAbbreviationTypeId.ShouldBe((int) StateAbbreviationTypeEnum.CA);
            studentAddress.City.ShouldBe("London");
            studentAddress.AddressTypeId.ShouldBe((int) AddressTypeEnum.Home);

            var studentParentAssociation = _student.StudentParentAssociations.First();
            studentParentAssociation.RelationTypeId.ShouldBe((int) RelationTypeEnum.Grandmother);
            studentParentAssociation.PrimaryContactStatus.ShouldBe(true);
            studentParentAssociation.LivesWith.ShouldBe(false);

            var parent = studentParentAssociation.Parent;

            parent.FirstName.ShouldBe("Jenny");
            parent.LastSurname.ShouldBe("Doe");
            parent.SexTypeId.ShouldBe((int) SexTypeEnum.Female);

            var parentTelephone = parent.ParentTelephones.First();
            parentTelephone.TelephoneNumberTypeId.ShouldBe((int) TelephoneNumberTypeEnum.Emergency1);
            parentTelephone.TelephoneNumber.ShouldBe("555-0221");

            var parentEmail = parent.ParentElectronicMails.First();
            parentEmail.ElectronicMailAddress.ShouldBe("Jenny@grandma.com");
            parentEmail.ElectronicMailTypeId.ShouldBe((int) ElectronicMailTypeEnum.HomePersonal);

            var parentAddress = parent.ParentAddresses.First();
            parentAddress.City.ShouldBe("Austin");
            parentAddress.StateAbbreviationTypeId.ShouldBe((int) StateAbbreviationTypeEnum.TX);
            parentAddress.PostalCode.ShouldBe("70101");
            parentAddress.StreetNumberName.ShouldBe("1 Oak St");
            parentAddress.ApartmentRoomSuiteNumber.ShouldBe("1A");
        }

        private void SetUp()
        {
            _mapper = new CreateStudentModelToStudentMapper(
                new StudentHomeAddressMapper(), 
                new StudentHomeLanguageMapper(),
                new CreateParentModelToStudentParentAssociationMapper(new CreateParentModelToParentMapper(), new CreateParentModelToParentAddressMapper()));

            _createStudentModel.StudentUsi = 10001;
            _createStudentModel.FirstName = "John";
            _createStudentModel.LastName = "Doe";
            _createStudentModel.Sex = SexTypeEnum.Male;
            _createStudentModel.BirthDate = new DateTime(2001, 1, 1);
            _createStudentModel.HispanicLatinoEthnicity = false;
            _createStudentModel.Race = RaceTypeEnum.AmericanIndianAlaskanNative;
            _createStudentModel.Address = "1060 W Addison St";
            _createStudentModel.Address2 = "33";
            _createStudentModel.City = "London";
            _createStudentModel.HomeLanguage = LanguageDescriptorEnum.English;
            _createStudentModel.PostalCode = "60657";
            _createStudentModel.State = StateAbbreviationTypeEnum.CA;

            _parentEnrollmentInfoModel = new CreateParentModel
            {
                FirstName = "Jenny",
                LastName = "Doe",
                RelationshipToStudent = RelationTypeEnum.Grandmother,
                Sex = SexTypeEnum.Female,
                MakeThisPrimaryContact = true,
                TelephoneNumber = "555-0221",
                EmailAddress = "Jenny@grandma.com",
                SameAddressAsStudent = false,
                City = "Austin",
                State = StateAbbreviationTypeEnum.TX,
                PostalCode = "70101",
                Address = "1 Oak St",
                Address2 = "1A"
            };

            _createStudentModel.FirstParent = _parentEnrollmentInfoModel;


        }
    }
}
