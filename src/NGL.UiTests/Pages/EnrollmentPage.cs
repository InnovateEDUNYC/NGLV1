using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;
using TestStack.Seleno.PageObjects;
using By = OpenQA.Selenium.By;

namespace NGL.UiTests.Pages
{
    class EnrollmentPage : Page<CreateStudentModel>
    {
        public StudentIndexPage Enroll()
        {
            return Navigate.To<StudentIndexPage>(By.ClassName("btn"));
        }

        
        public void InputParentInfoModel(ParentEnrollmentInfoModel parentEnrollmentInfoModel)
        {
            Input.ReplaceInputValueWith("BirthDate", "12/12/12");
            Input.ReplaceInputValueWith("ParentEnrollmentInfoModel_ParentUsi",
                parentEnrollmentInfoModel.ParentUsi.ToString());
            Input.ReplaceInputValueWith("ParentEnrollmentInfoModel_ParentFirstName",
                parentEnrollmentInfoModel.ParentFirstName);
            Input.ReplaceInputValueWith("ParentEnrollmentInfoModel_ParentLastName",
                parentEnrollmentInfoModel.ParentLastName);
            Input.ReplaceInputValueWith("ParentEnrollmentInfoModel_SexTypeEnum",
                parentEnrollmentInfoModel.SexTypeEnum.ToString());
        }
    }

}
