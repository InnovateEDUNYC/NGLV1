using System.Collections.Generic;
using System.Linq;

namespace NGL.Web.Models.Session
{
    public class SessionToSessionWithSectionsModelMapper : MapperBase<Data.Entities.Session, SessionWithSectionsModel>
    {
        public override void Map(Data.Entities.Session source, SessionWithSectionsModel target)
        {
            target.Name = source.SessionName;
            target.CourseRows = GetCourseRows(source.Sections);
        }

        private IList<CourseRowModel> GetCourseRows(IEnumerable<Data.Entities.Section> sections)
        {
            var sectionsByCourseCode = sections.GroupBy(s => s.LocalCourseCode);
            return sectionsByCourseCode.Select(grouping => new CourseRowModel
            {
                Name = grouping.Key,
                SectionRows = GetSectionRows(grouping)
            }).ToList();
        }

        private static List<SectionRowModel> GetSectionRows(IEnumerable<Data.Entities.Section> sectionGrouping)
        {
            return sectionGrouping.Select(s => new SectionRowModel
            {
                UniqueSectionCode = s.UniqueSectionCode,
                ClassPeriod = s.ClassPeriodName,
                Location = s.ClassroomIdentificationCode
            }).ToList();
        }
    }
}