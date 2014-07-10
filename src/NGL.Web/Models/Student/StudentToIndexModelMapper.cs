namespace NGL.Web.Models.Student
{
    public class StudentToIndexModelMapper : MapperBase<Data.Entities.Student, IndexModel>
    {
        public override void Map(Data.Entities.Student source, IndexModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}