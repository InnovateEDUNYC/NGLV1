using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class SessionToSessionIndexModelMapper :
         IMapper<Data.Entities.Session, SessionIndexModel>
    {
        public void Map(Data.Entities.Session source, SessionIndexModel target)
        {
            target.TermType = ((TermTypeEnum)source.TermTypeId).Humanize();
            target.SchoolYearType = ((SchoolYearTypeEnum)source.SchoolYear).Humanize();
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}