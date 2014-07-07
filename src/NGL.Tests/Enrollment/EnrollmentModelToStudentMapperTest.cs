using System;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class EnrollmentModelToStudentMapperTest
    {
        private EnrollmentModelToStudentMapper _mapper;
        readonly Student _student = new Student();
        readonly EnrollmentModel _enrollmentModel = new EnrollmentModel();

        [Fact]
        public void ShouldMapEnrollmentModelToStudent()
        {
            SetUp();
            _mapper.Map(_enrollmentModel, _student);

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
        }

        private void SetUp()
        {
            _mapper = new EnrollmentModelToStudentMapper();

            _enrollmentModel.StudentUsi = 10001;
            _enrollmentModel.FirstName = "John";
            _enrollmentModel.LastName = "Doe";
            _enrollmentModel.SexTypeEnum = SexTypeEnum.Male;
            _enrollmentModel.BirthDate = new DateTime(2001, 1, 1);
            _enrollmentModel.HispanicLatinoEthnicity = false;
            _enrollmentModel.OldEthnicityTypeEnum = OldEthnicityTypeEnum.AmericanIndianOrAlaskanNative;

            _enrollmentModel.StreetNumberName = "1060 W Addison St";

            _enrollmentModel.ApartmentRoomSuiteNumber = "33";
            _enrollmentModel.City = "London";
            
            _enrollmentModel.LanguageDescriptorEnum = LanguageDescriptorEnum.English;
            _enrollmentModel.PostalCode = "60657";
            _enrollmentModel.StateAbbreviationTypeEnum = StateAbbreviationTypeEnum.CA;
        }
    }
}
