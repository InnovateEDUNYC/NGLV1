using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class StudentToGradeModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var student = new StudentBuilder().WithFirstName("Hugo").WithLastSurname("Range").Build();

            var gradeModel = new StudentToGradeModelMapper().Build(student);

            gradeModel.StudentFirstName.ShouldBe(student.FirstName);
            gradeModel.StudentLastName.ShouldBe(student.LastSurname);

        }
    }
}
