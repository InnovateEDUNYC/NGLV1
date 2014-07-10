using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileModelMapper : MapperBase<Data.Entities.Student, ProfileModel>
    {
        public override void Map(Data.Entities.Student source, ProfileModel target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.BirthDate = source.BirthDate;
            if (source.OldEthnicityTypeId != null)
                target.Race = ((OldEthnicityTypeEnum) source.OldEthnicityTypeId).Humanize();
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.Sex = ((SexTypeEnum)source.SexTypeId).Humanize();
        }
    }
}