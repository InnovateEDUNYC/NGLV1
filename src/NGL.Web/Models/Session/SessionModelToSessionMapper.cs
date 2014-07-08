using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Session
{
    public class SessionModelToSessionMapper : IMapper<SessionModel, Data.Entities.Session>
    {
        private readonly ISchoolRepository _schoolRepository;

        public SessionModelToSessionMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void Map(SessionModel source, Data.Entities.Session target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.TermTypeId = (int) source.TermTypeEnum.GetValueOrDefault();
            target.SchoolYear = source.SchoolYear;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.SessionName = string.Empty;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}