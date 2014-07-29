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

        public static class Spring2038Semester
        {
            public const TermTypeEnum Term = TermTypeEnum.SpringSemester;
            public const SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2038;
            public static DateTime BeginDate = new DateTime(2038, 08, 30);
            public static DateTime EndDate = new DateTime(2038, 12, 12);
            public const int TotalInstructionalDays = 120;
        }

        public static class Math101
        {
            public const string CourseCode = "ZMATH101";
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
            public static string ClassPeriodName = "ZPeriod 1";
        }

        public static class RoomA101
        {
            public const string ClassRoomIdentificationCode = "Z101";
            public const int MaximumNumberOfSeats = 40;
            public const int OptimalNumberOfSeats = 30;
        }
    }
}
