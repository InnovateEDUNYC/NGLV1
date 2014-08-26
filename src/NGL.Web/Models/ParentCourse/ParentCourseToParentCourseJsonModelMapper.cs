namespace NGL.Web.Models.ParentCourse
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
