using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Session
{
    public class SessionCreateModelToSessionMapper : IMapper<SessionCreateModel, Data.Entities.Session>
    {
        private readonly ISchoolRepository _schoolRepository;

        public SessionCreateModelToSessionMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void Map(SessionCreateModel source, Data.Entities.Session target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.TermTypeId = (int) source.TermType.GetValueOrDefault();
            target.SchoolYear = (short) source.SchoolYearType;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.SessionName = string.Empty;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}