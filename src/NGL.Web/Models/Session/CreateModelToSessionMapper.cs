using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Session
{
    public class CreateModelToSessionMapper : IMapper<CreateModel, Data.Entities.Session>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToSessionMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void Map(CreateModel source, Data.Entities.Session target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.TermTypeId = (int) source.Term.GetValueOrDefault();
            target.SchoolYear = (short) source.SchoolYear;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.SessionName = string.Empty;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}