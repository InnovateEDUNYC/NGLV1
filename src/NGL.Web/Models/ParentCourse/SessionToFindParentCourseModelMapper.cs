using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class SessionToFindParentCourseModelMapper : MapperBase<Data.Entities.Session, FindParentCourseModel>
    {
        public override void Map(Data.Entities.Session source, FindParentCourseModel target)
        {
            target.Session = source.SessionName;
            target.SessionId = source.SessionIdentity;
        }
    }
}