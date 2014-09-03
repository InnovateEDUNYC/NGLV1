using Humanizer;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Section;
using Shouldly;
using Xunit;

namespace NGL.Tests.Section
{
    public class SectionToIndexModelMapperTests
    {
        [Fact]
        public void ShouldMapSectionToIndexModel()
        {
            var entity = new SectionBuilder().Build();
            var model = new SectionToIndexModelMapper().Build(entity);
            
            model.SectionIdentity.ShouldBe(entity.SectionIdentity);
            model.SchoolYear.ShouldBe(((SchoolYearTypeEnum)entity.SchoolYear).Humanize());
            model.Term.ShouldBe(((TermTypeEnum)entity.TermTypeId).Humanize());
            model.ClassPeriod.ShouldBe(entity.ClassPeriodName);
            model.Classroom.ShouldBe(entity.ClassroomIdentificationCode);
            model.LocalCourseCode.ShouldBe(entity.LocalCourseCode);
            model.UniqueSectionCode.ShouldBe(entity.UniqueSectionCode);
        }
    }
}
