using System;
using System.Net.Mail;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.UiTests.Enrollment
{
    public class CreateStudentModelFactory
    {
        private static readonly DateTime BirthDate = new DateTime(1999, 1, 5);
        private const int StudentUsi = 123240;
        private const string FirstName = "Jane";
        private const string LastName = "Novak";
        private const SexTypeEnum SexTypeEnum = Web.Data.Entities.SexTypeEnum.Female;
        private const bool HispanicLatinoEthnicity = true;
        private const RaceTypeEnum AmericanIndianAlaskanNative = RaceTypeEnum.AmericanIndianAlaskanNative;
        private const string Address1 = "123 Oak St";
        private const string Address2 = "1A";
        private const string City = "Springfield";
        private const StateAbbreviationTypeEnum StateAbbreviationTypeEnum = Web.Data.Entities.StateAbbreviationTypeEnum.CA;
        private const string PostalCode = "6000";
        private const LanguageDescriptorEnum LanguageDescriptorEnum = Web.Data.Entities.LanguageDescriptorEnum.English;

        public static CreateStudentModel CreateStudent()
        {
            return new CreateStudentModel
            {
                StudentUsi = StudentUsi,
                FirstName = FirstName,
                LastName = LastName,
                Sex = SexTypeEnum,
                BirthDate = BirthDate,
                HispanicLatinoEthnicity = HispanicLatinoEthnicity,
                Race = AmericanIndianAlaskanNative,
                Address = Address1,
                Address2 = Address2,
                City = City,
                State = StateAbbreviationTypeEnum,
                PostalCode = PostalCode,
                HomeLanguage = LanguageDescriptorEnum,
                FirstParent = ParentModelFactory.CreateParentWithAddress(),
                SecondParent = ParentModelFactory.CreateParentWithAddress()
            };
        }
    }
}
