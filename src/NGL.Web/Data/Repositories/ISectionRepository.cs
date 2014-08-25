using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface ISectionRepository
    {
        Section GetWithStudentAttendance(int sectionIdentity);
        Section GetWithStudentsAndSession(int sectionIdentity);
        Section GetWithAttendanceFlags(int? sectionId);
    }
}
