using NGL.Web.Data.Entities;
using NGL.Web.Models.School;

namespace NGL.Web.Models
{
    public class SessionToSessionModelMapper :
        IMapper<Session, SessionModel>
    {
        public void Map(Session source, SessionModel target)
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