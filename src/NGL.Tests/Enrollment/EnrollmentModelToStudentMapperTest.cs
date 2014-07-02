using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class EnrollmentModelToStudentMapperTest
    {
        EnrollmentModelToStudentMapper mapper = new EnrollmentModelToStudentMapper();
        Student student = new Student();
        EnrollmentModel enrollmentModel = new EnrollmentModel();

        [Fact]
        public void ShouldMapEnrollmentModelToStudent()
        {
            setUp();
            mapper.Map(enrollmentModel, student);

            student.FirstName.ShouldBe("John");
            student.LastSurname.ShouldBe("Doe");
            student.SexTypeId.ShouldBe(1);
            student.BirthDate.ShouldBe(new DateTime(2001, 1, 1));
            student.HispanicLatinoEthnicity.ShouldBe(false);
            student.OldEthnicityTypeId.ShouldBe(100);
            student.StudentLanguages.First().LanguageDescriptorId.ShouldBe(98);
            student.StudentLanguages.First().StudentLanguageUses.First().LanguageUseTypeId.ShouldBe(99);
            
            var studentAddress = student.StudentAddresses.First();
            
            studentAddress.StreetNumberName.ShouldBe("1060 W Addison St");
            studentAddress.ApartmentRoomSuiteNumber.ShouldBe("33");
            studentAddress.PostalCode.ShouldBe("60657");
            studentAddress.StateAbbreviationTypeId.ShouldBe(23);
            studentAddress.City.ShouldBe("London");
        }

        private void setUp()
        {
            enrollmentModel.StudentUSI = 10001;
            enrollmentModel.FirstName = "John";
            enrollmentModel.LastSurname = "Doe";
            enrollmentModel.SexTypeId = 1;
            enrollmentModel.BirthDate = new DateTime(2001, 1, 1);
            enrollmentModel.HispanicLatinoEthnicity = false;
            enrollmentModel.OldEthnicityTypeId = 100;

            enrollmentModel.StreetNumberName = "1060 W Addison St";

            enrollmentModel.ApartmentRoomSuiteNumber = "33";
            enrollmentModel.City = "London";
            enrollmentModel.LanguageDescriptorId = 98;
            enrollmentModel.LanguageUseTypeId = 99;
            enrollmentModel.PostalCode = "60657";
            enrollmentModel.StateAbbreviationTypeId = 23;
        }
    }
}
