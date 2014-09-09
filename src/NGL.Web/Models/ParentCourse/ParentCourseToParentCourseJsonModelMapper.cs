namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseToParentCourseJsonModelMapper : MapperBase<Data.Entities.ParentCourse, ParentCourseJsonModel>
    {
        public override void Map(Data.Entities.ParentCourse source, ParentCourseJsonModel target)
        {
            var compositeName = source.ParentCourseCode + " - " + source.ParentCourseTitle;
            target.LabelName = compositeName;
            target.ValueName = compositeName;
            target.Id = source.Id;
        }
    }
}
