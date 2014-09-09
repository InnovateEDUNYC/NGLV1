using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Session;

namespace NGL.Tests.Builders
{
    public class SessionModelBuilder
    {
        private readonly DateTime _beginDate = new DateTime(2038, 08, 30);
        private readonly DateTime _dateTime = new DateTime(2038, 12, 12);
        private const int TotalInstructionalDays = 120;
        private const TermTypeEnum TermTypeEnum = Web.Data.Entities.TermTypeEnum.SpringSemester;
        private const SchoolYearTypeEnum SchoolYearTypeEnum = Web.Data.Entities.SchoolYearTypeEnum.Year2038;

        public CreateModel Build()
        {
            return new CreateModel
            {
                Term = TermTypeEnum,
                SchoolYear = SchoolYearTypeEnum,
                BeginDate = _beginDate,
                EndDate = _dateTime,
                TotalInstructionalDays = TotalInstructionalDays
            };
        }
    }
}
