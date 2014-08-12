using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IStudentSectionAttendanceRepository
    {
        IEnumerable<StudentSectionAttendanceEvent> GetByStudentSectionAssociation(StudentSectionAssociation studentSectionAssociation);
    }
}