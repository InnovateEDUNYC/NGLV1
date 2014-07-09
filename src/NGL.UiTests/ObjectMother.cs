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
    }
}
