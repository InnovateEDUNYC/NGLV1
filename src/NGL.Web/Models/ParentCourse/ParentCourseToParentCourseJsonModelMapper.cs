namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseToParentCourseJsonModelMapper : MapperBase<Web.Data.Entities.ParentCourse, ParentCourseJsonModel>
    {
        public override void Map(Web.Data.Entities.ParentCourse source, ParentCourseJsonModel target)
        {
            var compositeName = source.ParentCourseCode + " - " + source.ParentCourseTitle;
            target.LabelName = compositeName;
            target.ValueName = compositeName;
            target.Id = source.Id;
        }
    }
}
