namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseToIndexModelMapper : MapperBase<Web.Data.Entities.ParentCourse, IndexModel>
    {
        public override void Map(Data.Entities.ParentCourse source, IndexModel target)
        {
            target.ParentCourseCode = source.ParentCourseCode;
            target.ParentCourseDescription = source.ParentCourseDescription;
            target.ParentCourseTitle = source.ParentCourseTitle;
            target.Id = source.Id;
        }
    }
}