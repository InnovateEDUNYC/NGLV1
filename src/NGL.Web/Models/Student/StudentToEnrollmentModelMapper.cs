namespace NGL.Web.Models.Student
{
    public class StudentToEnrollmentModelMapper : IMapper<Data.Entities.Student, EnrollmentModel>
    {
        public void Map(Data.Entities.Student source, EnrollmentModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}