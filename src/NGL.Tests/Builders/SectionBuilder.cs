using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class SectionBuilder
    {
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermTypeId = (int) TermTypeEnum.FallSemester;
        private const string ClassPeriodName = "Period 3";
        private const string ClassroomIdentificationCode = "BKL 200";
        private const string LocalCourseCode = "CHEM2090";
        private const string UniqueSectionCode = "CHEM2090 - 200";
        private const int SequenceOfCourse = 1;
        private readonly List<Web.Data.Entities.Student> _students = new List<Web.Data.Entities.Student>(); 
        private readonly List<Web.Data.Entities.Assessment> _assessments = new List<Web.Data.Entities.Assessment>();
        private readonly ICollection<StudentSectionAssociation> _studentSectionAssociations = new List<StudentSectionAssociation>();
        private readonly ICollection<AssessmentSection> _assessmentSections = new List<AssessmentSection>();

        private Web.Data.Entities.Section _section;
        private Web.Data.Entities.Session _session = new Web.Data.Entities.Session{ SessionName = "Fall 2014" };
        private DateTime _beginDate = new DateTime(2014, 6, 1);
        private DateTime _endDate = new DateTime(2015, 1, 20);

        public Web.Data.Entities.Section Build()
        {
            
            _section = new Web.Data.Entities.Section
            {
                SchoolId = Constants.SchoolId,
                SchoolYear = SchoolYear,
                TermTypeId = TermTypeId,
                ClassPeriodName = ClassPeriodName,
                ClassroomIdentificationCode = ClassroomIdentificationCode,
                LocalCourseCode = LocalCourseCode,
                UniqueSectionCode = UniqueSectionCode,
                SequenceOfCourse = SequenceOfCourse,
                Session = _session
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
    }
}
