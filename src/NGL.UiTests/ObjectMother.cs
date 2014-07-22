using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;

namespace NGL.UiTests
{
    internal static class ObjectMother
    {
        public static class UserJohnSmith
        {
            private const string Username = "JohnSmith";
            private const string Password = "123123";

            public static LoginModel ViewModel
            {
                get
                {
                    return

                        new LoginModel
                        {
                            Username = Username,
                            Password = Password
                        };
                }
            }
        }

        public static class Fall2014Semester
        {
            public const TermTypeEnum Term = TermTypeEnum.FallSemester;
            public const SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2014;
            public static DateTime BeginDate = new DateTime(2014, 08, 30);
            public static DateTime EndDate = new DateTime(2014, 12, 12);
            public const int TotalInstructionalDays = 120;
        }

        public static class Math101
        {
            public const string CourseCode = "MATH101";
            public const string CourseTitle = "Pre Algebra";
            public const int NumberOfParts = 1;
            public const AcademicSubjectDescriptorEnum AcademicSubject = AcademicSubjectDescriptorEnum.Mathematics;
            public const string CourseDescription = "This is a math class";
            public static DateTime DateCourseAdopted = new DateTime(2014, 07, 06);
            public const bool HighSchoolCourseRequirement = false;

            public const CourseGPAApplicabilityTypeEnum CourseGpaApplicability =
                CourseGPAApplicabilityTypeEnum.Applicable;

            public const CourseDefinedByTypeEnum CourseDefinedBy = CourseDefinedByTypeEnum.School;
            public const CreditTypeEnum MinimumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
            public const decimal MinimumAvailableCreditConversion = 3m;
            public const decimal MinimumAvailableCredit = 3m;
            public const CreditTypeEnum MaximumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
            public const decimal MaximumAvailableCreditConversion = 3m;
            public const decimal MaximumAvailableCredit = 3m;
            public const CareerPathwayTypeEnum CareerPathway = CareerPathwayTypeEnum.HospitalityandTourism;
            public const int TimeRequiredForCompletion = 2000;

        }

        public static class PeriodOne
        {
            public static string ClassPeriodName = "Period 1";
        }

        public static class RoomA101
        {
            public const string ClassRoomIdentificationCode = "A101";
            public const int MaximumNumberOfSeats = 40;
            public const int OptimalNumberOfSeats = 30;
        }

        public static class StudentJane
        {
            public const int StudentUsi = 123240;
            public const string FirstName = "Jane";
            public const string LastName = "Novak";
            public const SexTypeEnum Sex = SexTypeEnum.Female;
            public static DateTime? BirthDate = new DateTime(1999, 1, 5);
            public const bool HispanicLatinoEthnicity = true;
            public const RaceTypeEnum Race = RaceTypeEnum.AmericanIndianAlaskanNative;
            public const string Address = "123 Oak St";
            public const string Address2 = "1A";
            public const string City = "Springfield";
            public const StateAbbreviationTypeEnum State = StateAbbreviationTypeEnum.CA;
            public const string PostalCode = "6000";
            public const LanguageDescriptorEnum HomeLanguage = LanguageDescriptorEnum.English;
        }

        public static class StudentJanesDad
        {
            public const string FirstName = "Roberto";
            public const string LastName = "Mayorga";
            public const SexTypeEnum Sex = SexTypeEnum.Male;
            public const RelationTypeEnum RelationshipToStudent = RelationTypeEnum.Father;
            public const bool MakeThisPrimaryContact = true;
            public const string TelephoneNumber = "123-4567";
            public const string EmailAddress = "roberto@mail.co";
            public const bool SameAddressAsStudent = false;
            public const string Address = "890 Willow Ave";
            public const string Address2 = "flr 4";
            public const string City = "Honolulu";
            public const StateAbbreviationTypeEnum State = StateAbbreviationTypeEnum.NM;
            public const string PostalCode = "27890";
        }
    }
}
