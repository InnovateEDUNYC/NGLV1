using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class SessionByTermTypeAndSchoolYearQuery : IQuery<Session>
    {
        private readonly int _termTypeId;
        private readonly short _schoolYear;

        public SessionByTermTypeAndSchoolYearQuery(int termTypeId, short schoolYear)
        {
            _termTypeId = termTypeId;
            _schoolYear = schoolYear;
        }

        public IQueryable<Session> ApplyPredicate(IQueryable<Session> inputSet)
        {
            return inputSet.Where(s => s.TermTypeId == _termTypeId
                && s.SchoolYear == _schoolYear);
        }
    }
}