namespace NGL.Web.Models.Student
{
    public class StudentToNameModelMapper : MapperBase<Data.Entities.Student, NameModel>
    {
        public override void Map(Data.Entities.Student source, NameModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.StudentUsi = source.StudentUSI;
        }
    }
}