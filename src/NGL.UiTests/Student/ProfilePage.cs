using Humanizer;
using NGL.UiTests.Schedule;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class ProfilePage : Page<ProfileModel>
    {
        public bool AllFieldsExist(CreateStudentModel createStudentModel)
        {
            var studentFields =
                Browser.PageSource.Contains(createStudentModel.StudentUsi.ToString()) &&
                Browser.PageSource.Contains(createStudentModel.FirstName) &&
                Browser.PageSource.Contains(createStudentModel.LastName) &&
                Browser.PageSource.Contains(createStudentModel.Sex.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.BirthDate.GetValueOrDefault().ToString("MM-dd-yyyy")) &&
                Browser.PageSource.Contains(createStudentModel.HispanicLatinoEthnicity.ToString()) &&
                Browser.PageSource.Contains(createStudentModel.Race.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.HomeLanguage.GetValueOrDefault().ToString()) &&
                Browser.PageSource.Contains(createStudentModel.Address) &&
                Browser.PageSource.Contains(createStudentModel.Address2) &&
                Browser.PageSource.Contains(createStudentModel.City) &&
                Browser.PageSource.Contains(createStudentModel.State.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.PostalCode);


            var parentOneFields =
                Browser.PageSource.Contains(createStudentModel.FirstParent.FirstName) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.LastName) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.Sex.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.RelationshipToStudent.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.TelephoneNumber) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.EmailAddress) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.Address) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.Address2) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.City) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.State.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.FirstParent.PostalCode);

            var parentTwoFields =
                Browser.PageSource.Contains(createStudentModel.SecondParent.FirstName) &&
                Browser.PageSource.Contains(createStudentModel.SecondParent.LastName) &&
                Browser.PageSource.Contains(createStudentModel.SecondParent.Sex.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.SecondParent.RelationshipToStudent.Humanize()) &&
                Browser.PageSource.Contains(createStudentModel.SecondParent.TelephoneNumber);

            return studentFields && parentOneFields && parentTwoFields;
        }

        public SchedulePage GoToSchedulePage()
        {
            return Navigate.To<SchedulePage>(By.LinkText("Scheduling"));
        }

        public bool AttendancePercentageIs(string attendancePercentage)
        {
            var percentage = Find.Element(By.Id("profile-attendance-percentage-value"));
            return percentage.Text == attendancePercentage;
        }
    }
}
