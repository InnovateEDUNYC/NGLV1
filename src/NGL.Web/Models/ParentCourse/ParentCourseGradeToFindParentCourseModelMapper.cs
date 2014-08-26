using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradeToFindParentCourseModelMapper : MapperBase<ParentCourseGrade, FindParentCourseModel>
    {
        public override void Map(ParentCourseGrade source, FindParentCourseModel target)
        {
            target.ParentCourse = source.ParentCourse.ParentCourseTitle;
            target.ParentCourseId = source.ParentCourseId;
            target.Session = source.Session.SessionName;
            target.SessionId = source.Session.SessionIdentity;
        }
    }
}