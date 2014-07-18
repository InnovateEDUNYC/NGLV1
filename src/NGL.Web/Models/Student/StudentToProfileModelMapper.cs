using System.Collections;
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileModelMapper : MapperBase<Data.Entities.Student, ProfileModel>
    {
        private IMapper<Data.Entities.Student, ProfileHomeLanguageModel> _studentToProfileHomeLanguageModelMapper;

        public StudentToProfileModelMapper(IMapper<Data.Entities.Student, ProfileHomeLanguageModel> studentToProfileHomeLanguageModelMapper)
        {
            _studentToProfileHomeLanguageModelMapper = studentToProfileHomeLanguageModelMapper;
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

        }
    }
}