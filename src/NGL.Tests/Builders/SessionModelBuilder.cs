using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Session;

namespace NGL.Tests.Builders
{
    public class SessionModelBuilder
    {
        private readonly DateTime _beginDate = new DateTime(2038, 08, 30);
        private readonly DateTime _dateTime = new DateTime(2038, 12, 12);
        private const int _totalInstructionalDays = 120;
        private const TermTypeEnum _termTypeEnum = TermTypeEnum.SpringSemester;
        private const SchoolYearTypeEnum _schoolYearTypeEnum = SchoolYearTypeEnum.Year2038;

        public CreateModel Build()
        {
            return new CreateModel
            {
                Term = _termTypeEnum,
                SchoolYear = _schoolYearTypeEnum,
                BeginDate = _beginDate,
                EndDate = _dateTime,
                TotalInstructionalDays = _totalInstructionalDays
            };
        }
    }
}
