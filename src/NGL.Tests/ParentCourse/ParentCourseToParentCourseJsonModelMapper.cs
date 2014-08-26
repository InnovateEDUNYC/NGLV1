using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;

namespace NGL.Tests.ParentCourse
{
    public class ParentCourseToParentCourseJsonModelMapper : MapperBase<Web.Data.Entities.ParentCourse, ParentCourseJsonModel>
    {
        public override void Map(Web.Data.Entities.ParentCourse source, ParentCourseJsonModel target)
        {
            target.LabelName = source.ParentCourseTitle;
            target.ValueName = source.ParentCourseTitle;
            target.Id = source.Id;
        }
    }
}
