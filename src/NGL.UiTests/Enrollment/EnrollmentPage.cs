using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using Shouldly;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    class EnrollmentPage : Page<CreateStudentModel>
    {
        public AcademicDetailPage Enroll(CreateStudentModel createStudentModel)
        {
            if (createStudentModel.HispanicLatinoEthnicity)
            {
                Input.TickCheckbox(m => m.HispanicLatinoEthnicity, true);    
            }

            if (!createStudentModel.FirstParent.SameAddressAsStudent)
            {
                Input.TickCheckbox(m => m.FirstParent.SameAddressAsStudent, false);
            }
            Input.Model(createStudentModel);

            return Navigate.To<AcademicDetailPage>(By.ClassName("btn"));
        }
    }
}
