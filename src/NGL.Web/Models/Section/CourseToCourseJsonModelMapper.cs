namespace NGL.Web.Models.Section
{
    public class CourseToCourseJsonModelMapper : MapperBase<Data.Entities.Course, CourseJsonModel>
    {
        public override void Map(Data.Entities.Course source, CourseJsonModel target)
        {
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
        }
    }
}