using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class SectionToParentCourseGradeMapper : MapperBase<Data.Entities.Section, ParentCourseGrade>
    {
        public override void Map(Data.Entities.Section source, ParentCourseGrade target)
        {
            target.TermTypeId = source.TermTypeId;
            target.SchoolYear = source.SchoolYear;
            target.SchoolId = source.SchoolId;
        }
    }
}