namespace NGL.Web.Models.ParentCourse
{
    public class EditModelToParentCourseMapper : MapperBase<EditModel, Web.Data.Entities.ParentCourse>
    {
        public override void Map(EditModel source, Data.Entities.ParentCourse target)
        {
            target.ParentCourseCode = source.ParentCourseCode;
            target.ParentCourseDescription = source.ParentCourseDescription;
            target.ParentCourseTitle = source.ParentCourseTitle;
        }
    }
}