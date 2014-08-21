using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class ParentCourseGradeToGradeModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var student = new StudentBuilder()
                .WithFirstName("Hugo")
                .WithLastSurname("Range")
                .WithStudentUsi(12345)
                .Build();
            var parentCourseGrade = new ParentCourseGradeBuilder().WithStudent(student).Build();
            var gradeModel = new ParentCourseGradeToGradeModelMapper().Build(parentCourseGrade);

            gradeModel.StudentFirstName.ShouldBe(student.FirstName);
            gradeModel.StudentLastName.ShouldBe(student.LastSurname);
            gradeModel.StudentUSI.ShouldBe(student.StudentUSI);
            gradeModel.Grade.ShouldBe(parentCourseGrade.GradeEarned);
        }
    }
}
