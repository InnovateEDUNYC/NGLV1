using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class SectionsBySectionNameAndSessionQuery : IQuery<Section>
    {
        private readonly string _searchString;
        private readonly Session _session;

        public SectionsBySectionNameAndSessionQuery(string searchString, Session session)
        {
            _searchString = searchString;
            _session = session;
        }

        public IQueryable<Section> ApplyPredicate(IQueryable<Section> inputSet)
        {
            return inputSet.Where(s =>
                (s.UniqueSectionCode.ToLower().Contains(_searchString.ToLower()) ||
                 s.LocalCourseCode.ToLower().Contains(_searchString.ToLower())) &&
                s.SchoolYear == _session.SchoolYear &&
                s.TermTypeId == _session.TermTypeId);
        }
    }
}