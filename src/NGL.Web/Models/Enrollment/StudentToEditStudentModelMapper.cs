using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentToEditStudentModelMapper : MapperBase<Data.Entities.Student, EditStudentModel>
    {
        public override void Map(Data.Entities.Student source, EditStudentModel target)
        {
            target.StudentModel = new StudentModel
            {
                StudentUsi = source.StudentUSI,
                FirstName = source.FirstName,
                LastName = source.LastSurname,
                BirthDate = source.BirthDate,
                HispanicLatinoEthnicity = source.HispanicLatinoEthnicity,
                Sex = (SexTypeEnum) source.SexTypeId
            };
        }          
    }
}