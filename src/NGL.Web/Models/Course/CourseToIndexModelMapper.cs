using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CourseToIndexModelMapper : IMapper<Data.Entities.Course, IndexModel>
    {

        public void Map(Data.Entities.Course source, IndexModel target)
        {
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
            target.CourseDescription = source.CourseDescription;
        }
    }
}