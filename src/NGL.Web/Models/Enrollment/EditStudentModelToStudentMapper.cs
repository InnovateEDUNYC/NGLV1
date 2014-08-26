using NGL.Web.Models;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public class EditStudentModelToStudentMapper : MapperBase<EditStudentModel, Web.Data.Entities.Student>
    {
        public override void Map(EditStudentModel source, Web.Data.Entities.Student target)
        {
            target.FirstName = source.StudentModel.FirstName;
            target.LastSurname = source.StudentModel.LastName;
            target.BirthDate = source.StudentModel.BirthDate;
            target.SexTypeId = (int) source.StudentModel.Sex;
            target.HispanicLatinoEthnicity = source.StudentModel.HispanicLatinoEthnicity;
        }
    }
}
