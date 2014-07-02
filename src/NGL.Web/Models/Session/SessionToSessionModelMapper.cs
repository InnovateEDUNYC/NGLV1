namespace NGL.Web.Models.Session
{
    public class SessionToSessionModelMapper :
        IMapper<Data.Entities.Session, SessionModel>
    {
        public void Map(Data.Entities.Session source, SessionModel target)
        {
            target.TermTypeId = source.TermTypeId;
            target.SchoolYear = source.SchoolYear;
            target.SessionName = source.SessionName;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}