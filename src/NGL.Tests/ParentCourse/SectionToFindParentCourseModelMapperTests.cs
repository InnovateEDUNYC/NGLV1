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
    public class SectionToFindParentCourseModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var section = new SectionBuilder().Build();

            var findParentCourseModel = new SectionToFindParentCourseModelMapper().Build(section);

            findParentCourseModel.Section.ShouldBe(section.UniqueSectionCode);
            findParentCourseModel.SectionId.ShouldBe(section.SectionIdentity);
            findParentCourseModel.Session.ShouldBe(section.Session.SessionName);
            findParentCourseModel.SessionId.ShouldBe(section.Session.SessionIdentity);
        }
    }
}
