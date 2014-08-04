using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class CourseOfferingByPrimaryKeysQuery : IQuery<CourseOffering>
    {
        private readonly string _localCourseCode;
        private readonly short _schoolYear;
        private readonly int _termTypeId;

        public CourseOfferingByPrimaryKeysQuery(string localCourseCode, short schoolYear, int termTypeId)
        {
            _localCourseCode = localCourseCode;
            _schoolYear = schoolYear;
            _termTypeId = termTypeId;
        }

        public IQueryable<CourseOffering> ApplyPredicate(IQueryable<CourseOffering> inputSet)
        {
            return inputSet.Where(c => c.LocalCourseCode == _localCourseCode
                                && c.SchoolYear == _schoolYear
                                && c.TermTypeId == _termTypeId);
        }
    }
}