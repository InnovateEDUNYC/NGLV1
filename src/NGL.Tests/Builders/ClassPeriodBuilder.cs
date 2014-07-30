namespace NGL.Tests.Builders
{
    public class ClassPeriodBuilder
    {
        private string _classPeriodName = "Period Z";

        public ClassPeriodBuilder WithName(string name)
        {
            _classPeriodName = name;
            return this;
        }

        public Web.Data.Entities.ClassPeriod Build()
        {
            return new Web.Data.Entities.ClassPeriod
            {
                SchoolId = Constants.SchoolId,
                ClassPeriodName = _classPeriodName
            };
        }
    }
}
