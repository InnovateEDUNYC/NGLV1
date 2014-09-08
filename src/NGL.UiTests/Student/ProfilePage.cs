using System.Linq;
using System.Web.WebPages;
using Humanizer;
using NGL.UiTests.Schedule;
using NGL.Web.Extensions;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using OpenQA.Selenium;
using TestStack.Seleno.Extensions;
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
            return InputBiographicalInfoValues(profileModel);
        }

        private ProfilePage InputBiographicalInfoValues(ProfileModel profileModel)
        {
            WaitFor.AjaxCallsToComplete();
            Execute.Script("$('#Sex').val('" + profileModel.BiographicalInfo.Sex + "')");
            Execute.Script("$('#BirthDate').val('" + profileModel.BiographicalInfo.BirthDate + "')");
            Execute.Script("$('#HispanicLatinoEthnicity').attr('checked'," +
                           profileModel.BiographicalInfo.HispanicLatinoEthnicity.ToString().ToLower() + ")");
            Execute.Script("$('#Race').val('" + profileModel.BiographicalInfo.Race + "')");
            Execute.Script("$('#HomeLanguage').val('" + profileModel.BiographicalInfo.HomeLanguage + "')");
            Execute.Script("$('#save-biographical-info-edit').click()");
            return this;
        }

        public bool EditedBiographicalInformationIsVisable(EditableStudentBiographicalInfoModel newBiographicalInformation)
        {
            WaitFor.AjaxCallsToComplete();
            var sex = Browser.PageSource.Contains(newBiographicalInformation.Sex.Humanize());
            var birthday = Browser.PageSource.Contains(newBiographicalInformation.BirthDate);
            var latino = Browser.PageSource.Contains(newBiographicalInformation.HispanicLatinoEthnicity.ToString());
            var race = Browser.PageSource.Contains(newBiographicalInformation.Race.Humanize());
            var language = Browser.PageSource.Contains(newBiographicalInformation.HomeLanguage.ToString());

            return sex && birthday && language && latino && race;
        }

        public EditAcademicDetailsPanel EditAcademicDetails()
        {
            return Navigate.To<EditAcademicDetailsPanel>(By.Id("edit-academic-details-button"));
        }


        public EditProgramStatusPanel EditProgramStatus()
        {
            return Navigate.To<EditProgramStatusPanel>(By.Id("edit-program-status-button"));
        }

        public EditHomeAddressPanel EditHomeAddress()
        {
            return Navigate.To<EditHomeAddressPanel>(By.Id("edit-home-address-button"));
        }

        public bool IsProgramStatusInfoSameAs(EnterProgramStatusModel enterProgramStatusModel)
        {
            Find.Element(By.CssSelector("#readonly-program-status > h4")).Click();

            var testingAccommodation = Find.Element(By.Name("testing-accommodation")).Text.Equals(enterProgramStatusModel.TestingAccommodation.Value.ToYesNoString());
            var bilingualProgram = Find.Element(By.Name("bilingual-program")).Text.Equals(enterProgramStatusModel.BilingualProgram.Value.ToYesNoString());
            var englishAsSecondLanguage = Find.Element(By.Name("esl")).Text.Equals(enterProgramStatusModel.EnglishAsSecondLanguage.Value.ToYesNoString());
            var gifted = Find.Element(By.Name("gifted")).Text.Equals(enterProgramStatusModel.Gifted.Value.ToYesNoString());
            var specialEducation = Find.Element(By.Name("special-education")).Text.Equals(enterProgramStatusModel.SpecialEducation.Value.ToYesNoString());
            var titleParticipation = Find.Element(By.Name("title-participation")).Text.Equals(enterProgramStatusModel.TitleParticipation.Value.ToYesNoString());
            var mckinneyvento = Find.Element(By.Name("mckinneyvento")).Text.Equals(enterProgramStatusModel.McKinneyVento.Value.ToYesNoString());
            var foodServicesEligibility = Find.Element(By.Name("food-services")).Text.Equals(enterProgramStatusModel.FoodServicesEligibilityStatus.Humanize(LetterCasing.Title));

            return testingAccommodation && bilingualProgram && englishAsSecondLanguage && gifted 
                    && specialEducation && titleParticipation && mckinneyvento && foodServicesEligibility;
        }

        public bool EditedNameIsVisible(NameModel nameModel)
        {
            return (Browser.PageSource.Contains(nameModel.FirstName) &&
                Browser.PageSource.Contains(nameModel.LastName));
        }

        public ProfilePage EditName(NameModel nameModel)
        {
            Execute.Script("$('#edit-student-name-button').click()");
            Execute.Script("$('#FirstName').val('" + nameModel.FirstName + "')");
            Execute.Script("$('#LastName').val('" + nameModel.LastName + "')");
            Execute.Script("$('#save-student-name-edit').click()");
            WaitFor.AjaxCallsToComplete();
            return this;
        }

        public bool IsHomeAddressSameAs(HomeAddressModel homeAddressModel)
        {
            Find.Element(By.CssSelector("#readonly-home-address > h4")).Click();

            var sameAddress = Find.Element(By.Name("Address")).Text.Equals(homeAddressModel.Address);
            var sameAddress2 = Find.Element(By.Name("Address 2")).Text.Equals(homeAddressModel.Address2);
            var sameCity = Find.Element(By.Name("City")).Text.Equals(homeAddressModel.City);
            var sameState = Find.Element(By.Name("State")).Text.Equals(homeAddressModel.State.ToString());
            var samePostalCode = Find.Element(By.Name("Postal code")).Text.Equals(homeAddressModel.PostalCode);

            return sameAddress && sameAddress2 && sameCity && sameState && samePostalCode;
        }

        public bool IsAcademicDetailAccordingTo(EditAcademicDetailModel academicDetailModel)
        {
            Find.Element(By.CssSelector("#readonly-academic-details > h4")).Click();

            var writingScore = Find.Element(By.Name("WritingScore")).Text.AsDecimal().Equals(academicDetailModel.WritingScore);
            var mathScore = Find.Element(By.Name("MathScore")).Text.AsDecimal().Equals(academicDetailModel.MathScore);
            var readingScore = Find.Element(By.Name("ReadingScore")).Text.AsDecimal().Equals(academicDetailModel.ReadingScore);
            var performanceHistory = Find.Element(By.Name("PerformanceHistory")).Text.Equals(academicDetailModel.PerformanceHistory);

            return writingScore && mathScore && readingScore && performanceHistory;
        }
        public EditParentPanel EditParent(int parentNumber)
        {
            return Navigate.To<EditParentPanel>(By.Id("edit-parent-" + parentNumber + "-info-button"));
        }

        public bool IsParentSameAs(int parentNumber, EditProfileParentModel parentModel)
        {
            var sameFirstName = Browser.PageSource.Contains(parentModel.FirstName);
            var sameLastName = Browser.PageSource.Contains(parentModel.LastName);
            var sameSex = Browser.PageSource.Contains(parentModel.Sex.ToString());
            var sameRelationship = Browser.PageSource.Contains(parentModel.Relationship.Humanize());
            var sameTelephoneNumber = Browser.PageSource.Contains(parentModel.TelephoneNumber);
            var sameEmailAddress = Browser.PageSource.Contains(parentModel.EmailAddress);
            return sameFirstName
                   && sameLastName
                   && sameSex
                   && sameRelationship
                   && sameTelephoneNumber
                   && sameEmailAddress;
        }
    }

    public class EditParentPanel : Page<EditProfileParentModel>
    {
        public void Edit(int parentNumber, EditProfileParentModel parentModel)
        {
            Execute.Script("$('#editable-parent-"+parentNumber+"-info #FirstName').val('" + parentModel.FirstName + "')");
            Execute.Script("$('#editable-parent-"+parentNumber+"-info #LastName').val('" + parentModel.LastName + "')");
            Execute.Script("$('#editable-parent-" + parentNumber + "-info #Sex').val('" + parentModel.Sex + "')");
            Execute.Script("$('#editable-parent-" + parentNumber + "-info #Relationship').val('" + parentModel.Relationship + "')");
            Execute.Script("$('#editable-parent-" + parentNumber + "-info #TelephoneNumber').val('" + parentModel.TelephoneNumber + "')");
            Execute.Script("$('#editable-parent-" + parentNumber + "-info #EmailAddress').val('" + parentModel.EmailAddress + "')");
            Execute.Script("$('#editable-parent-" + parentNumber + "-info #SameAddressAsStudent').click()");
            if (!parentModel.SameAddressAsStudent)
            {
                Execute.Script("$('#editable-parent-" + parentNumber + "-info #EditableParentAddressModel_Address').val('" + parentModel.EditableParentAddressModel.Address + "')");
                Execute.Script("$('#editable-parent-" + parentNumber + "-info #EditableParentAddressModel_Address2').val('" + parentModel.EditableParentAddressModel.Address2 + "')");
                Execute.Script("$('#editable-parent-" + parentNumber + "-info #EditableParentAddressModel_City').val('" + parentModel.EditableParentAddressModel.City + "')");
                Execute.Script("$('#editable-parent-" + parentNumber + "-info #EditableParentAddressModel_State').val('" + parentModel.EditableParentAddressModel.State + "')");
                Execute.Script("$('#editable-parent-" + parentNumber + "-info #EditableParentAddressModel_PostalCode').val('" + parentModel.EditableParentAddressModel.PostalCode + "')");
            }

            Execute.Script("$('#save-parent-"+ parentNumber +"-info-edit').click()");
            WaitFor.AjaxCallsToComplete();
        }
    }
}
