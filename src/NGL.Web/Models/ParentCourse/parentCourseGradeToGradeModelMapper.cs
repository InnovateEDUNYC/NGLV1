namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradeToGradeModelMapper : MapperBase<Data.Entities.ParentCourseGrade, GradeModel>
    {
        public override void Map(Data.Entities.ParentCourseGrade source, GradeModel target)
        {
            target.StudentFirstName = source.Student.FirstName;
            target.StudentLastName = source.Student.LastSurname;
            target.StudentUSI = source.Student.StudentUSI;
            target.Grade = source.GradeEarned;
        }
    }
}