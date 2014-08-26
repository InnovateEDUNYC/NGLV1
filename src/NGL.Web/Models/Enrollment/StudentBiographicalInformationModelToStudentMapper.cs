using System;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public class StudentBiographicalInformationModelToStudentMapper : MapperBase<StudentBiographicalInformationModel, Web.Data.Entities.Student>
    {
        public override void Map(StudentBiographicalInformationModel source, Web.Data.Entities.Student target)
        {
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastName;
            target.BirthDate = DateTime.Parse(source.BirthDate);
            target.SexTypeId = (int) source.Sex;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
        }
    }
}
