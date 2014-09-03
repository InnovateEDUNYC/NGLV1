namespace NGL.Web.Models.Course
{
    public class CourseToIndexModelMapper : MapperBase<Data.Entities.Course, IndexModel>
    {

        public override void Map(Data.Entities.Course source, IndexModel target)
        {
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
            target.CourseDescription = source.CourseDescription;
            target.Identity = source.CourseIdentity;
        }
    }
}