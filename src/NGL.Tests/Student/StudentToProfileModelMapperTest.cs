using System;
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
        public void ShouldMap()
        {
            var studentAddress = new StudentAddress
            {
                AddressTypeId = (int)AddressTypeEnum.Home,
                StreetNumberName = "200 E Randolph",
                ApartmentRoomSuiteNumber = "25th Floor",
                City = "Chicago",
                StateAbbreviationTypeId = (int) StateAbbreviationTypeEnum.IL,
                PostalCode = "60601"
            };

            var studentRace = new StudentRace
            {
                RaceTypeId = (int) RaceTypeEnum.NativeHawaiianPacificIslander 
            };

            var studentLanguageUse = new StudentLanguageUse
            {
                LanguageUseTypeId = (int) LanguageUseTypeEnum.Homelanguage,
                LanguageDescriptorId = (int) LanguageDescriptorEnum.English
            };

            var studentLanguage = new StudentLanguage
            {
                LanguageDescriptorId = (int) LanguageDescriptorEnum.English
            };

            var student = new Web.Data.Entities.Student
            {
                StudentUSI = 1789,
                FirstName = "Bob",
                LastSurname = "Jenkins",
                SexTypeId = (int) SexTypeEnum.Male,
                BirthDate = new DateTime(2000, 2, 2),
                HispanicLatinoEthnicity = true,
            };


            student.StudentAddresses.Add(studentAddress);
            student.StudentRaces.Add(studentRace);

            studentLanguage.StudentLanguageUses.Add(studentLanguageUse);
            student.StudentLanguages.Add(studentLanguage);

            var studentDetailsModel = new ProfileModel();

            var mapper = new StudentToProfileModelMapper();
            mapper.Map(student, studentDetailsModel);

            studentDetailsModel.FirstName.ShouldBe("Bob");
            studentDetailsModel.LastName.ShouldBe("Jenkins");
            studentDetailsModel.BirthDate.ShouldBe(new DateTime(2000, 2, 2));
            studentDetailsModel.Race.ShouldBe(RaceTypeEnum.NativeHawaiianPacificIslander.Humanize());
            studentDetailsModel.HispanicLatinoEthnicity.ShouldBe(true);
            studentDetailsModel.Sex.ShouldBe(SexTypeEnum.Male.Humanize());
            studentDetailsModel.HomeLanguage.ShouldBe(LanguageDescriptorEnum.English.Humanize());
        }
    }
}
