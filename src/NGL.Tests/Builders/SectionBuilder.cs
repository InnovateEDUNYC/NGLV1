using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class SectionBuilder
    {
        private int _sectionIdentity = 1;
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermTypeId = (int) TermTypeEnum.FallSemester;
        private string _classPeriodName = "Period 3";
        private string _classroomIdentificationCode = "BKL 200";
        private string _localCourseCode = "CHEM2090";
        private string _uniqueSectionCode = "CHEM2090 - 200";
        private const int SequenceOfCourse = 1;
        private readonly List<Web.Data.Entities.Student> _students = new List<Web.Data.Entities.Student>();
        private readonly List<Web.Data.Entities.Assessment> _assessments = new List<Web.Data.Entities.Assessment>();
        private readonly ICollection<StudentSectionAssociation> _studentSectionAssociations = new List<StudentSectionAssociation>();
        private readonly ICollection<AssessmentSection> _assessmentSections = new List<AssessmentSection>();

        private Web.Data.Entities.Section _section;
        private readonly Web.Data.Entities.Session _session = new Web.Data.Entities.Session{ SessionName = "Fall 2014" };
        private readonly DateTime _beginDate = new DateTime(2014, 6, 1);
        private readonly DateTime _endDate = new DateTime(2015, 1, 20);
        private List<StudentSectionAttendanceEvent> _attendanceEvents;

        public Web.Data.Entities.Section Build()
        {
            
            _section = new Web.Data.Entities.Section
            {
                SectionIdentity = _sectionIdentity,
                SchoolId = Constants.SchoolId,
                SchoolYear = SchoolYear,
                TermTypeId = TermTypeId,
                ClassPeriodName = _classPeriodName,
                ClassroomIdentificationCode = _classroomIdentificationCode,
                LocalCourseCode = _localCourseCode,
                UniqueSectionCode = _uniqueSectionCode,
                SequenceOfCourse = SequenceOfCourse,
                Session = _session,
                StudentSectionAttendanceEvents = _attendanceEvents
            };
            MakeStudentSectionAssociations();
            MakeAssessmentSectionAssociations();

            return _section;
        }

        private void MakeAssessmentSectionAssociations()
        {
            foreach (var assessment in _assessments)
            {
                var assessmentSection = new AssessmentSection
                {
                    Assessment = assessment,
                    Section = _section
                };
                _assessmentSections.Add(assessmentSection);
                assessment.AssessmentSections.Add(assessmentSection);
            }
            _section.AssessmentSections = _assessmentSections;
        }

        private void MakeStudentSectionAssociations()
        {
            foreach (var student in _students)
            {
                var studentSectionAssociation = new StudentSectionAssociation
                {
                    Student = student,
                    StudentUSI = student.StudentUSI,
                    Section = _section,
                    BeginDate = _beginDate,
                    EndDate = _endDate
                };
                _studentSectionAssociations.Add(studentSectionAssociation);
                student.StudentSectionAssociations.Add(studentSectionAssociation);
            }
            _section.StudentSectionAssociations = _studentSectionAssociations;
        }

        public SectionBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _students.Add(student);
            return this;
        }

        public SectionBuilder WithAssessment(Web.Data.Entities.Assessment assessment)
        {
            _assessments.Add(assessment);
            return this;
        }

        public SectionBuilder WithSectionIdentity(int sectionIdentity)
        {
            _sectionIdentity = sectionIdentity;
            return this;
        }

        public SectionBuilder WithUniqueSectionCode(string uniqueSectionCode)
        {
            _uniqueSectionCode = uniqueSectionCode;
            return this;
        }

        public SectionBuilder WithLocalCourseCode(string localCourseCode)
        {
            _localCourseCode = localCourseCode;
            return this;
        }

        public SectionBuilder WithClassPeriodName(string classPeriodName)
        {
            _classPeriodName = classPeriodName;
            return this;
        }

        public SectionBuilder WithAttendanceEvents(List<StudentSectionAttendanceEvent> attendanceEvents){
            _attendanceEvents = attendanceEvents;
            return this;
        }
        
        public SectionBuilder WithClassroomIdentificationCode(string classroomIdentificationCode)
        {
            _classroomIdentificationCode = classroomIdentificationCode;
            return this;
        }
    }
}
