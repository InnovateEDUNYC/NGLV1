using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Section
{
    public class SectionToIndexModelMapper : MapperBase<Data.Entities.Section, IndexModel>
    {
        public override void Map(Data.Entities.Section source, IndexModel target)
        {
            target.SchoolYear = ((SchoolYearTypeEnum) source.SchoolYear).Humanize();
            target.Term = ((TermTypeEnum) source.TermTypeId).Humanize();
            target.ClassPeriod = source.ClassPeriodName;
            target.Classroom = source.ClassroomIdentificationCode;
            target.LocalCourseCode = source.LocalCourseCode;
            target.UniqueSectionCode = source.UniqueSectionCode;
            target.SequenceOfCourse = source.SequenceOfCourse;
        }
    }
}