using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class StudentToBiographicalInfoModelMapper : MapperBase<Data.Entities.Student, StudentBiographicalInformationModel>
    {
        public override void Map(Data.Entities.Student source, StudentBiographicalInformationModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.BirthDate = source.BirthDate;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.Sex = (SexTypeEnum) source.SexTypeId;
        }          
    }
}