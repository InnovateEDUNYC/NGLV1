using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Grade;
using Shouldly;
using Xunit;

namespace NGL.Tests.Grade
{
    public class ParentCourseGradeToCsvMapperTests
    {
        [Fact]
        public void ShouldMap()
        {

            var parentCourseGrade1 =
                new ParentCourseGradeBuilder().WithParentCourse(new ParentCourseBuilder().WithCourseCode("MATH12321").Build())
                    .WithStudent(new StudentBuilder().WithStudentUsi(2000).WithLastSurname("Jones").Build())
                    .Build(); 
            var parentCourseGrade2 =
                new ParentCourseGradeBuilder().WithParentCourse(new ParentCourseBuilder().WithCourseCode("ENGL432").Build())
                    .WithStudent(new StudentBuilder().WithStudentUsi(2001).WithLastSurname("White").Build())
                    .Build();

            var parentCourseGrades = new List<ParentCourseGrade>
            {
                parentCourseGrade1, parentCourseGrade2
            };

            var mapper = new ParentCourseGradeToCsvMapper();
            var gradesByteArray = mapper.Build(parentCourseGrades);

            var csvString = System.Text.Encoding.Default.GetString(gradesByteArray);
            var csvLines = csvString.Split(new [] { Environment.NewLine }, StringSplitOptions.None);

            csvLines.Count().ShouldBe(4);
            csvLines[0].ShouldBe("StudentLastName,StudentUSI,Course,Grade");
            csvLines[1].ShouldBe(parentCourseGrade1.Student.LastSurname + ","
                                 + parentCourseGrade1.StudentUSI + ","
                                 + parentCourseGrade1.ParentCourse.ParentCourseCode + ","
                                 + parentCourseGrade1.GradeEarned);
            csvLines[2].ShouldBe(parentCourseGrade2.Student.LastSurname + ","
                                 + parentCourseGrade2.StudentUSI + ","
                                 + parentCourseGrade2.ParentCourse.ParentCourseCode + ","
                                 + parentCourseGrade2.GradeEarned);
        }
    }
}
