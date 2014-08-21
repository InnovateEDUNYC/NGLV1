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

            return sectionsByCourseCode.Select(g => new CourseRowModel()
            {
                Name = g.Key
            }).ToList();
        }
    }
}