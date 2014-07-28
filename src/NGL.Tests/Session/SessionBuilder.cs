using System;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Session
{
    public class SessionBuilder
    {
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermType = (int) TermTypeEnum.FallSemester;
        private static readonly DateTime BeginDate = new DateTime(2014, 6, 26);
        private static readonly DateTime EndDate = new DateTime(2014, 9, 26);
        private const int TotalInstructionalDays = 92;

        public Web.Data.Entities.Session Build()
        {
            return new Web.Data.Entities.Session
            {
                SchoolId = Constants.SchoolId,
                TermTypeId = TermType,
                SchoolYear = SchoolYear,
                BeginDate = BeginDate,
                EndDate = EndDate,
                TotalInstructionalDays = TotalInstructionalDays
            };
        }
    }
}
