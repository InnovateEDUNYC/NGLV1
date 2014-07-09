using System;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateStudentModelToStudentMapperTest
    {
        private CreateStudentModelToStudentMapper _mapper;
        private readonly Web.Data.Entities.Student _student = new Web.Data.Entities.Student();
        readonly CreateStudentModel _createStudentModel = new CreateStudentModel();
        private ParentEnrollmentInfoModelToParentMapper _parentMapper;
        private ParentEnrollmentInfoModel _parentEnrollmentInfoModel;

        [Fact]
        public void ShouldMapCreateStudentModelToStudent()
        {
            SetUp();
            _mapper.Map(_createStudentModel, _student);

            const int languageDescriptorId = (int)LanguageDescriptorEnum.English;

            _student.FirstName.ShouldBe("John");
            _student.LastSurname.ShouldBe("Doe");
            _student.SexTypeId.ShouldBe(2);
            _student.BirthDate.ShouldBe(new DateTime(2001, 1, 1));
            _student.HispanicLatinoEthnicity.ShouldBe(false);
            _student.OldEthnicityTypeId.ShouldBe((int)OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative);
            _student.StudentLanguages.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);
            _student.StudentLanguages.First().StudentLanguageUses.First().LanguageUseTypeId.ShouldBe((int)LanguageUseTypeEnum.Homelanguage);
            _student.StudentLanguages.First().StudentLanguageUses.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);

            var studentAddress = _student.StudentAddresses.First();
            
            studentAddress.StreetNumberName.ShouldBe("1060 W Addison St");
            studentAddress.ApartmentRoomSuiteNumber.ShouldBe("33");
            studentAddress.PostalCode.ShouldBe("60657");
            studentAddress.StateAbbreviationTypeId.ShouldBe((int)StateAbbreviationTypeEnum.CA);
            studentAddress.City.ShouldBe("London");
            studentAddress.AddressTypeId.ShouldBe((int)AddressTypeEnum.Home);

            var parent = _student.StudentParentAssociations.First().Parent;

            parent.FirstName.ShouldBe("Jenny");
            parent.LastSurname.ShouldBe("Doe");
            parent.SexTypeId.ShouldBe((int) SexTypeEnum.Female);
        }

        private void SetUp()
        {
            _mapper = new CreateStudentModelToStudentMapper(new ParentEnrollmentInfoModelToParentMapper());

            _createStudentModel.StudentUsi = 10001;
            _createStudentModel.FirstName = "John";
            _createStudentModel.LastName = "Doe";
            _createStudentModel.SexTypeEnum = SexTypeEnum.Male;
            _createStudentModel.BirthDate = new DateTime(2001, 1, 1);
            _createStudentModel.HispanicLatinoEthnicity = false;
            _createStudentModel.OldEthnicityTypeEnum = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative;
            _createStudentModel.StreetNumberName = "1060 W Addison St";
            _createStudentModel.ApartmentRoomSuiteNumber = "33";
            _createStudentModel.City = "London";
            _createStudentModel.LanguageDescriptorEnum = LanguageDescriptorEnum.English;
            _createStudentModel.PostalCode = "60657";
            _createStudentModel.StateAbbreviationTypeEnum = StateAbbreviationTypeEnum.CA;

            _parentEnrollmentInfoModel = new ParentEnrollmentInfoModel
            {
                FirstName = "Jenny",
                LastName = "Doe",
                SexTypeEnum = SexTypeEnum.Female
            };

            _createStudentModel.ParentEnrollmentInfoModel = _parentEnrollmentInfoModel;


        }
    }
}
