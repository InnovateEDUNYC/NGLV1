using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Section
{
    public class SessionToSessionJSONModelMapper : MapperBase<Data.Entities.Session, SessionJSONModel>
    {
        public override void Map(Data.Entities.Session source, SessionJSONModel target)
        {
            target.SchoolYear = source.SchoolYear;
            target.Term = source.TermTypeId;
            target.SessionName = source.SessionName;
        }
    }
}