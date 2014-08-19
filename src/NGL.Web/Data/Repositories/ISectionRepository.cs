using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface ISectionRepository
    {
        Section GetWithStudentAttendanceForDate(int sectionIdentity, DateTime dateTime);
    }
}
