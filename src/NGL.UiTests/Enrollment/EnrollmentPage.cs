using NGL.Web.Models.Enrollment;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Enrollment
{
    public class EnrollmentPage : Page<CreateStudentModel>
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

            if (createStudentModel.AddSecondParent)
            {
                Input.TickCheckbox(m => m.AddSecondParent, true);
            }

            Input.Model(createStudentModel);

            return Navigate.To<AcademicDetailPage>(By.ClassName("btn"));
        }
    }
}
