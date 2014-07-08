using Humanizer;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class SessionToIndexModelMapper :
         IMapper<Data.Entities.Session, IndexModel>
    {
        public void Map(Data.Entities.Session source, IndexModel target)
        {
            target.Term = ((TermTypeEnum)source.TermTypeId).Humanize();
            target.SchoolYear = ((SchoolYearTypeEnum)source.SchoolYear).Humanize();
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.TotalInstructionalDays = source.TotalInstructionalDays;
        }
    }
}