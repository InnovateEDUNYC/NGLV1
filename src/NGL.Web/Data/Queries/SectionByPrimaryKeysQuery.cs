using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class SectionByPrimaryKeysQuery : IQuery<Section>
    {
        private readonly short _schoolYear;
        private readonly int _term;
        private readonly string _period;
        private readonly string _classroom;
        private readonly string _course;

        public SectionByPrimaryKeysQuery(
            short schoolYear, 
            int term, 
            string period, 
            string classroom, 
            string course)
        {
            _schoolYear = schoolYear;
            _term = term;
            _period = period;
            _classroom = classroom;
            _course = course;
        }

        public IQueryable<Section> ApplyPredicate(IQueryable<Section> inputSet)
        {
            return inputSet.Where(
                s => s.SchoolYear == _schoolYear &&
                    s.TermTypeId == _term &&
                    s.ClassPeriodName == _period &&
                    s.ClassroomIdentificationCode == _classroom &&
                    s.LocalCourseCode == _course
                );
        } 
    }
}