namespace NGL.Web.Models.Schedule
{
    public class SessionToSessionListItemModelMapper : MapperBase<Data.Entities.Session, SessionListItemModel>
    {
        public override void Map(Data.Entities.Session source, SessionListItemModel target)
        {
            target.SessionId = source.SessionIdentity;
            target.SessionName = source.SessionName;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
        }
    }
}