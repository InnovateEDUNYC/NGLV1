using NGL.Web.Models.ClassPeriod;

namespace NGL.Tests.ClassPeriod
{
    public class CreateClassPeriodModelBuilder
    {
        private string _classPeriodName = "Period 1";

        public CreateClassPeriodModelBuilder WithName(string name)
        {
            _classPeriodName = name;
            return this;
        }

        public CreateModel Build()
        {
            return new CreateModel
            {
                ClassPeriodName = _classPeriodName
            };
        }
    }
}
