using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGL.Tests.Builders
{
    class LocationBuilder
    {
        private const int SchoolId = 1;
        private const string ClassroomIdentificationCode = "Gym";

        public Web.Data.Entities.Location Build()
        {
            return new Web.Data.Entities.Location
            {
                ClassroomIdentificationCode = ClassroomIdentificationCode,
                SchoolId = SchoolId
            };
        }
    }
}
