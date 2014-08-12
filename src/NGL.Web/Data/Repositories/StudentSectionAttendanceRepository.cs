using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class StudentSectionAttendanceRepository : RepositoryBase, IStudentSectionAttendanceRepository
    {
        public StudentSectionAttendanceRepository(INglDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<StudentSectionAttendanceEvent> GetByStudentSectionAssociation(StudentSectionAssociation studentSectionAssociation)
        {
            return DbContext.Set<StudentSectionAttendanceEvent>()
                .Where(
                    ssae =>
                        ssae.ClassPeriodName == studentSectionAssociation.ClassPeriodName
                        && ssae.SchoolId == studentSectionAssociation.SchoolId
                        && ssae.ClassroomIdentificationCode == studentSectionAssociation.ClassroomIdentificationCode
                        && ssae.LocalCourseCode == studentSectionAssociation.LocalCourseCode
                        && ssae.TermTypeId == studentSectionAssociation.TermTypeId
                        && ssae.SchoolYear == studentSectionAssociation.SchoolYear
                        && ssae.StudentUSI == studentSectionAssociation.StudentUSI
                        && ssae.EventDate >= studentSectionAssociation.BeginDate
                        && ssae.EventDate <= studentSectionAssociation.EndDate
                        ).ToList();
        }
    }
}