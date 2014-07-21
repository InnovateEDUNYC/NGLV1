using System;
using System.Linq;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentToProfileModelMapperTest
    {
        [Fact]
        public void ShouldMapStudentToProfileModel()
        {

            var parentPhoneNumber = CreateParentPhoneNumber();
            var parentEmailAddress = CreateParentEmailAddress();
            var parent = CreateParent();
            parent.ParentTelephones.Add(parentPhoneNumber);
            parent.ParentElectronicMails.Add(parentEmailAddress);
            var studentAddress = CreateStudentAddress();
            var studentRace = CreateStudentRace();
            var studentLanguageUse = CreateStudentLanguageUse();
            var studentLanguage = CreateStudentLanguage();
            var student = CreateStudent();

            student.StudentAddresses.Add(studentAddress);
            student.StudentRaces.Add(studentRace);
            studentLanguage.StudentLanguageUses.Add(studentLanguageUse);
            student.StudentLanguages.Add(studentLanguage);
            
            var studentParentAssociation = CreateStudentParentAssociation(parent, student);

            student.StudentParentAssociations.Add(studentParentAssociation);
            parent.StudentParentAssociations.Add(studentParentAssociation);

            var profileModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper(new StudentToProfileHomeLanguageModelMapper(), new StudentToProfileParentModelMapper());
            mapper.Map(student, profileModel);

            profileModel.FirstName.ShouldBe("Bob");
            profileModel.LastName.ShouldBe("Jenkins");
            profileModel.BirthDate.ShouldBe(new DateTime(2000, 2, 2));
            profileModel.Race.ShouldBe(RaceTypeEnum.NativeHawaiianPacificIslander.Humanize());
            profileModel.HispanicLatinoEthnicity.ShouldBe(true);
            profileModel.Sex.ShouldBe(SexTypeEnum.Male.Humanize());
            var studentProfileHomeLanguages = profileModel.ProfileHomeLanguageModel.HomeLanguages;
            studentProfileHomeLanguages.First().ShouldBe(LanguageDescriptorEnum.English.Humanize());
            var profileParentModel = profileModel.ProfileParentModel;
            profileParentModel.FirstName.ShouldBe("Leroy");
            profileParentModel.LastName.ShouldBe("Jenkins");
            profileParentModel.Sex.ShouldBe(SexTypeEnum.Male.Humanize());
            profileParentModel.RelationshipToStudent.ShouldBe(RelationTypeEnum.Father.Humanize());
            profileParentModel.TelephoneNumber.ShouldBe("928-326-4567");
            profileParentModel.EmailAddress.ShouldBe("leroy@jenk.net");
            profileParentModel.SameAddressAsStudent.ShouldBe(true);
        }

        private StudentParentAssociation CreateStudentParentAssociation(Parent parent, Web.Data.Entities.Student student)
        {
            return new StudentParentAssociation
            {
                RelationTypeId = (int)RelationTypeEnum.Father,
                LivesWith = true,
                Parent = parent,
                Student = student
            };
        }

        private Web.Data.Entities.Student CreateStudent()
        {
            return new Web.Data.Entities.Student
            {
                StudentUSI = 1789,
                FirstName = "Bob",
                LastSurname = "Jenkins",
                SexTypeId = (int) SexTypeEnum.Male,
                BirthDate = new DateTime(2000, 2, 2),
                HispanicLatinoEthnicity = true,
            };
        }

        private StudentLanguage CreateStudentLanguage()
        {
            return new StudentLanguage
            {
                LanguageDescriptorId = (int) LanguageDescriptorEnum.English
            };
        }

        private StudentLanguageUse CreateStudentLanguageUse()
        {
            return new StudentLanguageUse
            {
                LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage,
                LanguageDescriptorId = (int) LanguageDescriptorEnum.English
            };
        }

        private StudentRace CreateStudentRace()
        {
            return new StudentRace
            {
                RaceTypeId = (int) RaceTypeEnum.NativeHawaiianPacificIslander 
            };
        }

        private StudentAddress CreateStudentAddress()
        {
            return new StudentAddress
            {
                AddressTypeId = (int)AddressTypeEnum.Home,
                StreetNumberName = "200 E Randolph",
                ApartmentRoomSuiteNumber = "25th Floor",
                City = "Chicago",
                StateAbbreviationTypeId = (int) StateAbbreviationTypeEnum.IL,
                PostalCode = "60601"
            };
        }

        private static Parent CreateParent()
        {
            return new Parent()
            {
                FirstName = "Leroy",
                LastSurname = "Jenkins",
                SexTypeId = (int) SexTypeEnum.Male,
            };
        }

        private ParentElectronicMail CreateParentEmailAddress()
        {
            return new ParentElectronicMail
            {
                ElectronicMailAddress = "leroy@jenk.net"
            };
        }

        private ParentTelephone CreateParentPhoneNumber()
        {
            var parentPhoneNumber = new ParentTelephone
            {
                TelephoneNumber = "928-326-4567",
                TelephoneNumberTypeId = (int) TelephoneNumberTypeEnum.Emergency1
            };
            return parentPhoneNumber;
        }
    }
}
