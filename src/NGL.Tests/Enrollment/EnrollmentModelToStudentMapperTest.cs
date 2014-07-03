using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class EnrollmentModelToStudentMapperTest
    {
        readonly EnrollmentModelToStudentMapper _mapper = new EnrollmentModelToStudentMapper();
        readonly Student _student = new Student();
        readonly EnrollmentModel _enrollmentModel = new EnrollmentModel();

        [Fact]
        public void ShouldMapEnrollmentModelToStudent()
        {
            SetUp();
            _mapper.Map(_enrollmentModel, _student);

            _student.FirstName.ShouldBe("John");
            _student.LastSurname.ShouldBe("Doe");
            _student.SexTypeId.ShouldBe(2);
            _student.BirthDate.ShouldBe(new DateTime(2001, 1, 1));
            _student.HispanicLatinoEthnicity.ShouldBe(false);
            _student.OldEthnicityTypeId.ShouldBe(100);
            const int languageDescriptorId = 98;
            _student.StudentLanguages.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);
            _student.StudentLanguages.First().StudentLanguageUses.First().LanguageUseTypeId.ShouldBe(99);
            _student.StudentLanguages.First().StudentLanguageUses.First().LanguageDescriptorId.ShouldBe(languageDescriptorId);

            var studentAddress = _student.StudentAddresses.First();
            
            studentAddress.StreetNumberName.ShouldBe("1060 W Addison St");
            studentAddress.ApartmentRoomSuiteNumber.ShouldBe("33");
            studentAddress.PostalCode.ShouldBe("60657");
            studentAddress.StateAbbreviationTypeId.ShouldBe(23);
            studentAddress.City.ShouldBe("London");
            studentAddress.AddressTypeId.ShouldBe(1);
        }

        private void SetUp()
        {
            _enrollmentModel.StudentUsi = 10001;
            _enrollmentModel.FirstName = "John";
            _enrollmentModel.LastSurname = "Doe";
            _enrollmentModel.SexTypeId = 2;
            _enrollmentModel.BirthDate = new DateTime(2001, 1, 1);
            _enrollmentModel.HispanicLatinoEthnicity = false;
            _enrollmentModel.OldEthnicityTypeId = 100;

            _enrollmentModel.StreetNumberName = "1060 W Addison St";

            _enrollmentModel.ApartmentRoomSuiteNumber = "33";
            _enrollmentModel.City = "London";
            _enrollmentModel.LanguageTypeId = 98;
            _enrollmentModel.LanguageUseTypeId = 99;
            _enrollmentModel.PostalCode = "60657";
            _enrollmentModel.StateAbbreviationTypeId = 23;
        }
    }
}
