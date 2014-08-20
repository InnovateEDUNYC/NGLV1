using System;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ISessionFilter _sessionFilter;

        public StudentService(IStudentRepository studentRepository, IAttendanceRepository attendanceRepository, ISessionFilter sessionFilter)
        {
            _studentRepository = studentRepository;
            _attendanceRepository = attendanceRepository;
            _sessionFilter = sessionFilter;
        }

        public Student GetStudent(int usi)
        {
            var student = _studentRepository.GetByUSI(usi);
            if (student == null)
                return null;

            var schoolYear = _sessionFilter.FindSession(DateTime.Now.Date).SchoolYear;
            var studentSectionAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(usi, schoolYear);
            student.StudentSectionAttendanceEvents = studentSectionAttendanceEvents;

            return student;
        }
    }
}