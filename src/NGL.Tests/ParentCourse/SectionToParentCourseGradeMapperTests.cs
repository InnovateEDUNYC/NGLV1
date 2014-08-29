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
    public class SectionToParentCourseGradeMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var section = new SectionBuilder().Build();
            var parentCourseId = new Guid();
            var parentCourseGrade = new SectionToParentCourseGradeMapper().Build(section, m =>
            {
                m.StudentUSI = 1;
                m.ParentCourseId = parentCourseId;
                m.GradeEarned = "FAIL";
            });

            parentCourseGrade.TermTypeId.ShouldBe(section.TermTypeId);
            parentCourseGrade.SchoolYear.ShouldBe(section.SchoolYear);
            parentCourseGrade.SchoolId.ShouldBe(section.SchoolId);
            parentCourseGrade.StudentUSI.ShouldBe(1);
            parentCourseGrade.ParentCourseId.ShouldBe(parentCourseId);
            parentCourseGrade.GradeEarned.ShouldBe("FAIL");
        }
    }
}
