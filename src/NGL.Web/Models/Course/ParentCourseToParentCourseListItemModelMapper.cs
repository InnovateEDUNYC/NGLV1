namespace NGL.Web.Models.Course
{
    public class ParentCourseToParentCourseListItemModelMapper : MapperBase<Data.Entities.ParentCourse, ParentCourseListItemModel>
    {
        public override void Map(Data.Entities.ParentCourse source, ParentCourseListItemModel target)
        {
            target.ParentCourseId = source.Id;
            target.ParentCourseTitle = source.ParentCourseTitle;
        }
    }
}