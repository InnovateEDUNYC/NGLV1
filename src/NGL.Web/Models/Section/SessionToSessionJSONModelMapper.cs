namespace NGL.Web.Models.Section
{
    public class SessionToSessionJsonModelMapper : MapperBase<Data.Entities.Session, SessionJsonModel>
    {
        public override void Map(Data.Entities.Session source, SessionJsonModel target)
        {
            target.SessionId = source.SessionIdentity;
            target.SessionName = source.SessionName;
        }
    }
}