using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Section
{
    public class SessionToSessionJSONModelMapper : MapperBase<Data.Entities.Session, SessionJSONModel>
    {
        public override void Map(Data.Entities.Session source, SessionJSONModel target)
        {
            target.SchoolYear = source.SchoolYear;
            target.SessionName = source.SessionName;
            target.Term = source.TermTypeId;
        }
    }
}