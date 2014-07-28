using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Session;

namespace NGL.Tests.Session
{
    public class CreateModelBuilder
    {
        private const SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2014;
        private const TermTypeEnum Term = TermTypeEnum.FallSemester;
        private static readonly DateTime BeginDate = new DateTime(2014, 6, 26);
        private static readonly DateTime EndDate = new DateTime(2014, 9, 26);
        private const int TotalInstructionalDays = 92;

        public CreateModel Build()
        {
            return new CreateModel
            {
                SchoolYear = SchoolYear,
                Term = Term,
                BeginDate = BeginDate,
                EndDate = EndDate,
                TotalInstructionalDays = TotalInstructionalDays
            };
        }
    }
}
