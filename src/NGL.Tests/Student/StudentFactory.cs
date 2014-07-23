using System;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class StudentFactory
    {
        private const int StudentUsi = 1789;
        private const string FirstName = "Bob";
        private const string LastName = "Jenkins";
        private const string Parent1FirstName = "Leroy";
        private const string Parent2FirstName = "Johanna";
        private const int Sex = (int) SexTypeEnum.Male;
        private static readonly DateTime BirthDate = new DateTime(2000, 2, 2);
        private const bool HispanicLatinoEthnicity = true;
        private const int Race = (int) RaceTypeEnum.NativeHawaiianPacificIslander;
        private const int PrimaryParentRelationType = (int) RelationTypeEnum.Father;

        public static Web.Data.Entities.Student CreateStudentWithOneParent()
        {
            return CreateStudentWithOneParent(ParentFactory.CreateParentWithoutAddress(), true);
        }

        public static Web.Data.Entities.Student CreateStudentWithOneParent(Parent parent, bool livesWith)
        {
            var student = CreateStudent();
            var studentParentAssociation = CreateStudentParentAssociation(parent, student, livesWith);

            student.StudentParentAssociations.Add(studentParentAssociation);
            parent.StudentParentAssociations.Add(studentParentAssociation);

            return student;
        }

        public static Web.Data.Entities.Student CreateStudentWithTwoParents()
        {
            var parentOne = ParentFactory.CreateParentWithoutAddress(Parent1FirstName);
            var parentTwo = ParentFactory.CreateParentWithoutAddress(Parent2FirstName);
            var student = CreateStudent();
            var studentParentAssociationOne = CreateStudentParentAssociation(parentOne, student, true);
            var studentParentAssociationTwo = CreateStudentParentAssociation(parentTwo, student, true);

            student.StudentParentAssociations.Add(studentParentAssociationOne);
            parentOne.StudentParentAssociations.Add(studentParentAssociationOne);
            student.StudentParentAssociations.Add(studentParentAssociationTwo);
            parentTwo.StudentParentAssociations.Add(studentParentAssociationTwo);
            return student;
        }

        private static Web.Data.Entities.Student CreateStudent()
        {
            var student = new Web.Data.Entities.Student
            {
                StudentUSI = StudentUsi,
                FirstName = FirstName,
                LastSurname = LastName,
                SexTypeId = Sex,
                BirthDate = BirthDate,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
            };

            student.StudentRaces.Add(CreateStudentRace());
            student.StudentAddresses.Add(StudentAddressFactory.CreateStudentAddress());
            student.StudentLanguages.Add(StudentLanguageFactory.CreateStudentLanguageWithHomeUse());
            return student;
        }

        private static StudentRace CreateStudentRace()
        {
            return new StudentRace
            {
                RaceTypeId = Race
            };
        }

        private static StudentParentAssociation CreateStudentParentAssociation(Parent parent, Web.Data.Entities.Student student, bool livesWith)
        {
            return new StudentParentAssociation
            {
                RelationTypeId = PrimaryParentRelationType,
                LivesWith = livesWith,
                Parent = parent,
                Student = student
            };
        }
    }
}
