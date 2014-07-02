using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class SessionModelToSessionMapper : IMapper<SessionModel, Data.Entities.Session>
    {
        public void Map(SessionModel source, Data.Entities.Session target)
        {
            target.SchoolId = source.SchoolId;
            target.TermTypeId = source.TermTypeId;
            target.SchoolYear = source.SchoolYear;
            target.SessionName = source.SessionName;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}