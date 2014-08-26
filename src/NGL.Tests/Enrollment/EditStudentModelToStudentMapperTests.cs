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
    public class EditStudentModelToStudentMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var editStudentModel = new EditStudentModelBuilder().Build();
            var mapper = new EditStudentModelToStudentMapper();
            var student = new StudentBuilder().Build();
            mapper.Map(editStudentModel, student);
            student.FirstName.ShouldBe(editStudentModel.StudentModel.FirstName);
            student.LastSurname.ShouldBe(editStudentModel.StudentModel.LastName);
            student.BirthDate.ShouldBe(editStudentModel.StudentModel.BirthDate);
            student.SexTypeId.ShouldBe((int)editStudentModel.StudentModel.Sex);
            student.HispanicLatinoEthnicity.ShouldBe(editStudentModel.StudentModel.HispanicLatinoEthnicity);
        }
    }

    public class EditStudentModelBuilder
    {
        private StudentModel _studentModel = new StudentModelBuilder().Build();

        public EditStudentModel Build()
        {
            return new EditStudentModel
            {
                StudentModel = _studentModel
            };
        }
    }

    public class StudentModelBuilder
    {
        private int _studentUsi = 3434;
        private string _firstName = "John";
        private string _lastName = "White";
        private DateTime _birthDate = new DateTime(2004, 6, 6);
        private SexTypeEnum _sex = SexTypeEnum.Male;
        private bool _hispanicLatinoEthnicity = false;
        public StudentModel Build()
        {
            return new StudentModel
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
