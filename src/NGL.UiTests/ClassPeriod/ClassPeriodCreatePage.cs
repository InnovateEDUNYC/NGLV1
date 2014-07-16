using NGL.Web.Models.ClassPeriod;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ClassPeriod
{
    public class ClassPeriodCreatePage : Page<CreateModel>
    {

        public ClassPeriodIndexPage CreateClassPeriod(CreateModel createClassPeriodModel)
        {
            Input.Model(createClassPeriodModel);
            return Navigate.To<ClassPeriodIndexPage>(By.ClassName("btn"));
        }

    }
}
