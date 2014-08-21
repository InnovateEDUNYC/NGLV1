using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Account;

namespace NGL.UiTests
{
    internal static class ObjectMother
    {
        public static class UserHellenSmith
        {
            private const string Username = "HellenSmith";
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
        public static class UserMasterAdmin
        {
            private const string Username = "MasterAdmin";
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
    }
}
