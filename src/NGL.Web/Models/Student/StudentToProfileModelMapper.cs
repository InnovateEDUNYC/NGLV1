using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileModelMapper : MapperBase<Data.Entities.Student, ProfileModel>
    {
        private readonly IMapper<Data.Entities.Student, ProfileHomeLanguageModel> _studentToProfileHomeLanguageModelMapper;
        private readonly IMapper<Data.Entities.Student, ProfileParentModel> _studentToProfileParentModelMapper;

        public StudentToProfileModelMapper(
            IMapper<Data.Entities.Student, ProfileHomeLanguageModel> studentToProfileHomeLanguageModelMapper, 
            IMapper<Data.Entities.Student, ProfileParentModel> studentToProfileParentModelMapper)
        {
            _studentToProfileHomeLanguageModelMapper = studentToProfileHomeLanguageModelMapper;
            _studentToProfileParentModelMapper = studentToProfileParentModelMapper;
        }

        public override void Map(Data.Entities.Student source, ProfileModel target)
        {
            target.StudentUsi = source.StudentUSI;
            target.FirstName = source.FirstName;
            target.LastName = source.LastSurname;
            target.Sex = ((SexTypeEnum)source.SexTypeId).Humanize();
            target.BirthDate = source.BirthDate;
            target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            target.Race = ((RaceTypeEnum) source.StudentRaces.First().RaceTypeId).Humanize();

            target.ProfileHomeLanguageModel = _studentToProfileHomeLanguageModelMapper.Build(source);

            var studentAddresses = source.StudentAddresses;
            
            var studentAddress = studentAddresses.First(address => address.AddressTypeId == (int)AddressTypeEnum.Home);
            target.Address = studentAddress.StreetNumberName;
            target.Address2 = studentAddress.ApartmentRoomSuiteNumber;
            target.City = studentAddress.City;
            target.State = ((StateAbbreviationTypeEnum) studentAddress.StateAbbreviationTypeId).Humanize();
            target.PostalCode = studentAddress.PostalCode;

            target.ProfileParentModel = _studentToProfileParentModelMapper.Build(source);
        }
    }
}