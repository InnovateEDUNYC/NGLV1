using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGL.Tests.Builders
{
    public class ClassPeriodBuilder
    {
        private const string ClassPeriodName = "Period 1";
        private const int SchoolId = 1;

        public Web.Data.Entities.ClassPeriod Build()
        {
            return new Web.Data.Entities.ClassPeriod
            {
                ClassPeriodName = ClassPeriodName,
                SchoolId = SchoolId
            };
        }
    }
}
