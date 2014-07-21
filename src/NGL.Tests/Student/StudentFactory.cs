using System;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Student
{
    public static class StudentFactory
    {
        public const int StudentUsi = 1789;
        public const string FirstName = "Bob";
        public const string LastName = "Jenkins";
        public const int Sex = (int) SexTypeEnum.Male;
        public static readonly DateTime BirthDate = new DateTime(2000, 2, 2);
        public const bool HispanicLatinoEthnicity = true;
        public const int Race = (int)RaceTypeEnum.NativeHawaiianPacificIslander;

        public const int PrimaryParentRelationType = (int) RelationTypeEnum.Father;
        public const bool LivesWithPrimaryParent = true;

        public static Web.Data.Entities.Student CreateStudentWithOneParent()
        {
            var student = CreateStudent();
            student.StudentRaces.Add(CreateStudentRace());
            student.StudentAddresses.Add(StudentAddressFactory.CreateStudentAddress());
            student.StudentLanguages.Add(StudentLanguageFactory.CreateStudentLanguageWithHomeUse());

            var parent = ParentFactory.CreateParentWithoutAddress();

            var studentParentAssociation = CreateStudentParentAssociation(parent, student);
            student.StudentParentAssociations.Add(studentParentAssociation);
            parent.StudentParentAssociations.Add(studentParentAssociation);

            return student;
        }

        private static Web.Data.Entities.Student CreateStudent()
        {
            return new Web.Data.Entities.Student
            {
                StudentUSI = StudentUsi,
                FirstName = FirstName,
                LastSurname = LastName,
                SexTypeId = Sex,
                BirthDate = BirthDate,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
            };
        }

        private static StudentRace CreateStudentRace()
        {
            return new StudentRace
            {
                RaceTypeId = Race
            };
        }

        private static StudentParentAssociation CreateStudentParentAssociation(Parent parent, Web.Data.Entities.Student student)
        {
            return new StudentParentAssociation
            {
                RelationTypeId = PrimaryParentRelationType,
                LivesWith = LivesWithPrimaryParent,
                Parent = parent,
                Student = student
            };
        }

    }
}
