using Humanizer;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Student
{
    public class ProfilePage : Page<ProfileModel>
    {
        public bool AllFieldsExist(CreateStudentModel profile)
        {
            return
                Browser.PageSource.Contains(profile.StudentUsi.ToString()) &&
                Browser.PageSource.Contains(profile.FirstName) &&
                Browser.PageSource.Contains(profile.LastName) &&
                Browser.PageSource.Contains(profile.Sex.Humanize()) &&
                Browser.PageSource.Contains(profile.BirthDate.GetValueOrDefault().ToString("MM-dd-yyyy")) &&
                Browser.PageSource.Contains(profile.HispanicLatinoEthnicity.ToString()) &&
                Browser.PageSource.Contains(profile.Race.Humanize()) &&
                Browser.PageSource.Contains(profile.Address) &&
                Browser.PageSource.Contains(profile.Address2) &&
                Browser.PageSource.Contains(profile.City) &&
                Browser.PageSource.Contains(profile.State.Humanize()) &&
                Browser.PageSource.Contains(profile.PostalCode);
        }

    }
}
