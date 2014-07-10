namespace NGL.Web.Models.Student
{
    public class StudentToIndexModelMapper : IMapper<Data.Entities.Student, IndexModel>
    {
        public void Map(Data.Entities.Student source, IndexModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}