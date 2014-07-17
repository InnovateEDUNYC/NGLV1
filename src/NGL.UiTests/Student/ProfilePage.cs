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
             var a=   Browser.PageSource.Contains(profile.StudentUsi.ToString());
           var b=     Browser.PageSource.Contains(profile.FirstName);
            var c=    Browser.PageSource.Contains(profile.LastName);
            var d=    Browser.PageSource.Contains(profile.Sex.Humanize());
            var e=    Browser.PageSource.Contains(profile.BirthDate.ToString("MM-dd-yyyy"));
             var f=   Browser.PageSource.Contains(profile.HispanicLatinoEthnicity.ToString());
              var g=  Browser.PageSource.Contains(profile.Race.Humanize());
          var h=      Browser.PageSource.Contains(profile.Address);
         var i=       Browser.PageSource.Contains(profile.Address2);
         var j=       Browser.PageSource.Contains(profile.City);
          var k=      Browser.PageSource.Contains(profile.State.Humanize());
        var l=        Browser.PageSource.Contains(profile.PostalCode);

            return a && b && c && d&& e && f && g && h&&i &&j &&k &&l;
        }

    }
}
