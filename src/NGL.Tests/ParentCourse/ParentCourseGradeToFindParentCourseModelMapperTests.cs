using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Builders;
using NGL.Tests.Session;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class ParentCourseGradeToFindParentCourseModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var session = new SessionBuilder().Build();
            var parentCourse = new ParentCourseBuilder().Build();
            var parentCourseGrade = new ParentCourseGradeBuilder().WithSession(session).WithParentCourse(parentCourse).Build();

            var findParentCourseModel = new ParentCourseGradeToFindParentCourseModelMapper().Build(parentCourseGrade);

            findParentCourseModel.ParentCourse.ShouldBe(parentCourseGrade.ParentCourse.ParentCourseTitle);
            findParentCourseModel.ParentCourseId.ShouldBe(parentCourseGrade.ParentCourseId);
            findParentCourseModel.Session.ShouldBe(parentCourseGrade.Session.SessionName);
            findParentCourseModel.SessionId.ShouldBe(parentCourseGrade.Session.SessionIdentity);
        }
    }
}
