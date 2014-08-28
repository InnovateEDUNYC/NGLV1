using System.ComponentModel.DataAnnotations;
using System.Linq;
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
                Browser.PageSource.Contains(createStudentModel.BirthDate.GetValueOrDefault().ToShortDateString()) &&
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

        public bool FlagCountIs(int flagCount)
        {
            var flags = Find.Elements(By.CssSelector("span.fa-flag"));
            return flags.Count() == flagCount;
        }

        public ProfilePage EditBiographicalInfo(ProfileModel profileModel)
        {
            var editButton = Find.Element(By.Id("edit-biographical-info-button"));
            editButton.Click();
            InputBiographicalInfoValues(profileModel);
            return this;
        }

        private void InputBiographicalInfoValues(ProfileModel profileModel)
        {
            Execute.Script("$('#Sex').val('" + profileModel.BiographicalInfo.Sex + "')");
            Execute.Script("$('#BirthDate').val('" + profileModel.BiographicalInfo.BirthDate + "')");
            Execute.Script("$('#HispanicLatinoEthnicity').attr('checked'," +
                           profileModel.BiographicalInfo.HispanicLatinoEthnicity.ToString().ToLower() + ")");
            Execute.Script("$('#Race').val('" + profileModel.BiographicalInfo.Race + "')");
            Execute.Script("$('#HomeLanguage').val('" + profileModel.BiographicalInfo.HomeLanguage + "')");
            Execute.Script("$('#save-biographical-info-edit').click()");
        }

        public bool EditedBiographicalInformationIsVisable(EditStudentBiographicalInfoModel newBiographicalInformation)
        {
            return Browser.PageSource.Contains(newBiographicalInformation.Sex.Humanize()) &&
                   Browser.PageSource.Contains(newBiographicalInformation.BirthDate) &&
                   Browser.PageSource.Contains(newBiographicalInformation.HispanicLatinoEthnicity.ToString()) &&
                   Browser.PageSource.Contains(newBiographicalInformation.Race.Humanize()) &&
                   Browser.PageSource.Contains(newBiographicalInformation.HomeLanguage.ToString());
        }
    }
}
