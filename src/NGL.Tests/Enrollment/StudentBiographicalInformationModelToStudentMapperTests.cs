using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class StudentBiographicalInformationModelToStudentMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var studentBiographicalInfo = new StudentBiographicalInformationModelBuilder().Build();
            var mapper = new StudentBiographicalInformationModelToStudentMapper();
            var student = new StudentBuilder().Build();
            mapper.Map(studentBiographicalInfo, student);
            student.FirstName.ShouldBe(studentBiographicalInfo.FirstName);
            student.LastSurname.ShouldBe(studentBiographicalInfo.LastName);
            student.BirthDate.ShouldBe(studentBiographicalInfo.BirthDate);
            student.SexTypeId.ShouldBe((int)studentBiographicalInfo.Sex);
            student.HispanicLatinoEthnicity.ShouldBe(studentBiographicalInfo.HispanicLatinoEthnicity);
        }
    }

    public class StudentBiographicalInformationModelBuilder
    {
        private int _studentUsi = 3434;
        private string _firstName = "John";
        private string _lastName = "White";
        private DateTime _birthDate = new DateTime(2004, 6, 6);
        private SexTypeEnum _sex = SexTypeEnum.Male;
        private bool _hispanicLatinoEthnicity = false;
        public StudentBiographicalInformationModel Build()
        {
            return new StudentBiographicalInformationModel
            {
                StudentUsi = _studentUsi,
                FirstName = _firstName,
                LastName = _lastName,
                BirthDate = _birthDate,
                Sex = _sex,
                HispanicLatinoEthnicity = _hispanicLatinoEthnicity
            };
        }
    }
}
