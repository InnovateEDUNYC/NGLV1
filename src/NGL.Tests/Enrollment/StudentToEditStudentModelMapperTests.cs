using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class StudentToEditStudentModelMapperTests
    {
        private StudentToEditStudentModelMapper _mapper;
        private Web.Data.Entities.Student _studentEntity;

        [Fact]
        public void ShouldMap()
        {
            SetUp();
            var editStudentModel = _mapper.Build(_studentEntity);
            editStudentModel.StudentModel.StudentUsi.ShouldBe(_studentEntity.StudentUSI);
            editStudentModel.StudentModel.FirstName.ShouldBe(_studentEntity.FirstName);
            editStudentModel.StudentModel.LastName.ShouldBe(_studentEntity.LastSurname);
            editStudentModel.StudentModel.Sex.ShouldBe(SexTypeEnum.Male);
            editStudentModel.StudentModel.BirthDate.ShouldBe(_studentEntity.BirthDate);
            editStudentModel.StudentModel.HispanicLatinoEthnicity.ShouldBe(_studentEntity.HispanicLatinoEthnicity);
        }                   

        private void SetUp()
        {
            _studentEntity = new StudentBuilder().Build();
            _mapper = new StudentToEditStudentModelMapper();
        }
    }
}
