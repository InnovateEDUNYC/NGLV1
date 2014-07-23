using System;
using System.Web;
using Humanizer;
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
        }

        public static class StudentJanesMom
        {
            public const string FirstName = "Maria";
            public const string LastName = "Mayorga";
            public const SexTypeEnum Sex = SexTypeEnum.Female;
            public const RelationTypeEnum RelationshipToStudent = RelationTypeEnum.Mother;
            public const bool MakeThisPrimaryContact = false;
            public const string TelephoneNumber = "439-4067";
            public const string EmailAddress = "maria@mail.co";
            public const bool SameAddressAsStudent = true;
        }
        public static class JanesAcademicDetails
        {
            public static decimal? Reading = 88.88m;
            public static decimal? Writing = 0m;
            public static decimal? Math = 100.00m;
            public static GradeLevelTypeEnum? AnticipatedGrade = GradeLevelTypeEnum._7thGrade;
            public const SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2014;
            public const string PerformanceHistory = "Needs writing practice";
            public static HttpPostedFileBase PerformanceHistoryFile = null;
            public static DateTime? EntryDate = new DateTime(2001, 1, 1);
            public static int StudentUsi = StudentJane.StudentUsi;
        }

        public static class JanesProgramStatus
        {
            public static bool? TestingAccommodation = true;
            public static bool? SpecialEducation = true;
            public static bool? McKinneyVento = false;
            public static bool? TitleParticipation = true;
            public static bool? BilingualProgram = false;
            public static bool? EnglishAsSecondLanguage = true;
            public static bool? Gifted = true;
            public static SchoolFoodServicesEligibilityTypeEnum FoodServiceEligibilityStatus =
                SchoolFoodServicesEligibilityTypeEnum.Fullprice;
            public static readonly HttpPostedFileBase TestingAccommodationFile = null;
            public static readonly HttpPostedFileBase SpecialEducationFile = null;
            public static readonly HttpPostedFileBase McKinneyVentoFile = null;
            public static readonly HttpPostedFileBase TitleParticipationFile = null;
        }
    }
}
