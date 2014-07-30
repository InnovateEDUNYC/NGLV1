namespace NGL.Web.Models.Section
{
    public class CourseToCourseListItemModelMapper : MapperBase<Data.Entities.Course, CourseListItemModel>
    {
        public override void Map(Data.Entities.Course source, CourseListItemModel target)
        {
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
        }
    }
}