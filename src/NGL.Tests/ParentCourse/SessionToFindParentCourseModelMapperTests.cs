using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using NGL.Tests.Builders;
using NGL.Tests.Session;
using NGL.Web.Models.ParentCourse;
using Shouldly;
using Xunit;

namespace NGL.Tests.ParentCourse
{
    public class SessionToFindParentCourseModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var session = new SessionBuilder().Build();
            var parentCourse = new ParentCourseBuilder().Build();
            
            var findParentCourseModel = new SessionToFindParentCourseModelMapper().Build(session, t =>
            {
                t.ParentCourse = parentCourse.ParentCourseTitle;
                t.ParentCourseId = parentCourse.Id;
            });

            findParentCourseModel.ParentCourse.ShouldBe(parentCourse.ParentCourseTitle);
            findParentCourseModel.ParentCourseId.ShouldBe(parentCourse.Id);
            findParentCourseModel.Session.ShouldBe(session.SessionName);
            findParentCourseModel.SessionId.ShouldBe(session.SessionIdentity);
        }
    }
}
