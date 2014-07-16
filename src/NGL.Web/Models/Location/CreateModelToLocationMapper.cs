using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Location
{
    public class CreateModelToLocationMapper : MapperBase<CreateModel, Data.Entities.Location>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToLocationMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.Location target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.ClassroomIdentificationCode = source.ClassroomIdentificationCode;
            target.MaximumNumberOfSeats = source.MaximumNumberOfSeats;
            target.OptimalNumberOfSeats = source.OptimalNumberOfSeats;
        }
    }
}