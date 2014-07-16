using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;

namespace NGL.UiTests
{
    class ObjectMother
    {
        public static class JohnSmith
        {
            public static string Username = "JohnSmith";
            public static string Password = "123123";

            public static LoginViewModel ViewModel
            {
                get
                {
                    return

                        new LoginViewModel
                        {
                            UserName = Username,
                            Password = Password
                        };
                }
            }
        }

        public static class Fall2014Semester
        {
            public static TermTypeEnum Term = TermTypeEnum.FallSemester;
            public static SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2014;
            public static System.DateTime BeginDate = new DateTime(2014, 08, 30);
            public static System.DateTime EndDate = new DateTime(2014, 12, 12);
            public static int TotalInstructionalDays = 120;
        }


        public static class Math101
        {
            public static string CourseCode = "MATH101";
            public static string CourseTitle = "Pre Algebra";
            public static int NumberOfParts = 1;
            public static AcademicSubjectDescriptorEnum AcademicSubject = AcademicSubjectDescriptorEnum.Mathematics;
            public static string CourseDescription = "This is a math class";
            public static DateTime DateCourseAdopted = new DateTime(2014, 07, 06);
            public static bool HighSchoolCourseRequirement = false;

            public static CourseGPAApplicabilityTypeEnum CourseGpaApplicability =
                CourseGPAApplicabilityTypeEnum.Applicable;

            public static CourseDefinedByTypeEnum CourseDefinedBy = CourseDefinedByTypeEnum.School;
            public static CreditTypeEnum MinimumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
            public static decimal MinimumAvailableCreditConversion = 3m;
            public static decimal MinimumAvailableCredit = 3m;
            public static CreditTypeEnum MaximumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
            public static decimal MaximumAvailableCreditConversion = 3m;
            public static decimal MaximumAvailableCredit = 3m;
            public static CareerPathwayTypeEnum CareerPathway = CareerPathwayTypeEnum.HospitalityandTourism;
            public static int TimeRequiredForCompletion = 2000;

        }

        public static class PeriodOne
        {
            public static string ClassPeriodName = "Period 1";
        }
    }
}
