using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NGL.Tests.Student;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentBuilder
    {
        private int _studentUsi = 999;
        private string _firstName = "Bob";
        private static string _lastName = "Jenkins";
        private const string Parent1FirstName = "Leroy";
        private const string Parent2FirstName = "Johanna";
        private const int Sex = (int)SexTypeEnum.Male;
        private readonly DateTime _birthDate = new DateTime(2000, 2, 2);
        private ICollection<StudentAcademicDetail> _studentAcademicDetails;
        private StudentProgramStatus _studentProgramStatus;
        private readonly ICollection<StudentParentAssociation> _studentParentAssociations = new Collection<StudentParentAssociation>();
        private List<StudentAssessment> _studentAssessments;
        private const bool HispanicLatinoEthnicity = true;
        private const int Race = (int)RaceTypeEnum.NativeHawaiianPacificIslander;
        private const int PrimaryParentRelationType = (int)RelationTypeEnum.Father;
        private IList<StudentSectionAttendanceEvent> _studentSectionAttendanceEvents  = new List<StudentSectionAttendanceEvent>();

        public Web.Data.Entities.Student Build()
        {
            var student = new Web.Data.Entities.Student
            {
                StudentUSI = _studentUsi,
                FirstName = _firstName,
                LastSurname = _lastName,
                SexTypeId = Sex,
                BirthDate = _birthDate,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
            };

            student.StudentRaces.Add(CreateStudentRace());
            student.StudentAddresses.Add(StudentAddressFactory.CreateStudentAddress());
            student.StudentLanguages.Add(StudentLanguageFactory.CreateStudentLanguageWithHomeUse());
            student.StudentAcademicDetails = _studentAcademicDetails;
            student.StudentProgramStatus = _studentProgramStatus;
            student.StudentParentAssociations = _studentParentAssociations;
            student.StudentAssessments = _studentAssessments;
            student.StudentSectionAttendanceEvents = _studentSectionAttendanceEvents;

            return student;
        }

        public StudentBuilder WithStudentAcademicDetails()
        {
            _studentAcademicDetails = new List<StudentAcademicDetail> {new StudentAcademicDetailBuilder().Build()};
            return this;
        }

        public StudentBuilder WithStudentProgramStatus()
        {
            _studentProgramStatus = new StudentProgramStatusBuilder().Build();
            return this;
        }

        public StudentBuilder WithParent(Parent parent=null, bool livesWith = true)
        {
            if (parent == null)
                parent = ParentFactory.CreateParentWithoutAddress();

            var studentParentAssociation = new StudentParentAssociation
            {
                RelationTypeId = PrimaryParentRelationType,
                LivesWith = livesWith,
                Parent = parent,
            };

            _studentParentAssociations.Add(studentParentAssociation);
            parent.StudentParentAssociations.Add(studentParentAssociation);
            return this;
        }

        public StudentBuilder WithStudentAssessments(List<StudentAssessment> studentAssessments)
        {
            _studentAssessments = studentAssessments;
            return this;
        }

        private static StudentRace CreateStudentRace()
        {
            return new StudentRace { RaceTypeId = Race };
        }

        public StudentBuilder WithStudentUsi(int studentUsi)
        {
            _studentUsi = studentUsi;
            return this;
        }

        public StudentBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }


        public StudentBuilder WithStudentSectionAttendanceEvents(
            IList<StudentSectionAttendanceEvent> studentSectionAttendanceEvents)
        {
            _studentSectionAttendanceEvents = studentSectionAttendanceEvents;
            return this;
        }

        public StudentBuilder WithLastSurname(string lastName)
        {
            _lastName = lastName;
            return this;
        }
    }
}
