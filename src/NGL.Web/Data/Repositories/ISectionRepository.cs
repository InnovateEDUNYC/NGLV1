using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface ISectionRepository
    {
        Section GetWithStudentAttendance(int sectionIdentity);
        Section GetWithAttendanceFlags(int? sectionIdentity);
        void Remove(int sectionIdentity);
        bool HasDependencies(int sectionIdentity);
    }
}
