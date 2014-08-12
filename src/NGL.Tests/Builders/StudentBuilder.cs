using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Tests.Student;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentBuilder
    {
        private const int StudentUsi = 999;
        private const string FirstName = "Bob";
        private const string LastName = "Jenkins";
        private const string Parent1FirstName = "Leroy";
        private const string Parent2FirstName = "Johanna";
        private const int Sex = (int)SexTypeEnum.Male;
        private readonly DateTime BirthDate = new DateTime(2000, 2, 2);
        private ICollection<StudentAcademicDetail> _studentAcademicDetails;
        private StudentProgramStatus _studentProgramStatus;
        private Web.Data.Entities.Student _student;
        private ICollection<StudentParentAssociation> _studentParentAssociations;
        private List<StudentAssessment> _studentAssessments;
        private const bool HispanicLatinoEthnicity = true;
        private const int Race = (int)RaceTypeEnum.NativeHawaiianPacificIslander;
        private const int PrimaryParentRelationType = (int)RelationTypeEnum.Father;

        public StudentBuilder()
        {
            _student = new Web.Data.Entities.Student
            {
                StudentUSI = StudentUsi,
                FirstName = FirstName,
                LastSurname = LastName,
                SexTypeId = Sex,
                BirthDate = BirthDate,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
            };
            _studentParentAssociations = new Collection<StudentParentAssociation>();
        }
        public Web.Data.Entities.Student Build()
        {
            _student.StudentRaces.Add(CreateStudentRace());
            _student.StudentAddresses.Add(StudentAddressFactory.CreateStudentAddress());
            _student.StudentLanguages.Add(StudentLanguageFactory.CreateStudentLanguageWithHomeUse());
            _student.StudentAcademicDetails = _studentAcademicDetails;
            _student.StudentProgramStatus = _studentProgramStatus;
            _student.StudentParentAssociations = _studentParentAssociations;
            _student.StudentAssessments = _studentAssessments;
            return _student;
        }

        public StudentBuilder WithStudentAcademicDetails()
        {
            _studentAcademicDetails = new List<StudentAcademicDetail>();
            _studentAcademicDetails.Add(new StudentAcademicDetailBuilder().Build());
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
                Student = _student
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
    }
}
