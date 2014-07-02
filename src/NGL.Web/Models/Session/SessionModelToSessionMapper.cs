using NGL.Web.Data.Entities;
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
            target.TermTypeId = source.TermTypeId;
            target.SchoolYear = source.SchoolYear;
            target.SessionName = source.SessionName;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}