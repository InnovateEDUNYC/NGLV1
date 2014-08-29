using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Session
{
    public class SessionBuilder
    {
        private const int SessionIdentity = 1;
        private short _schoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermType = (int) TermTypeEnum.FallSemester;
        private static readonly DateTime BeginDate = new DateTime(2014, 6, 26);
        private static readonly DateTime EndDate = new DateTime(2014, 9, 26);
        private const int TotalInstructionalDays = 92;
        private const string SessionName = "Fall Semester 2014";
        private IList<Web.Data.Entities.Section> _sections = new List<Web.Data.Entities.Section>();

        public Web.Data.Entities.Session Build()
        {
            return new Web.Data.Entities.Session
            {
                SessionIdentity = SessionIdentity,
                SchoolId = Constants.SchoolId,
                TermTypeId = TermType,
                SchoolYear = _schoolYear,
                SessionName = SessionName,
                BeginDate = BeginDate,
                EndDate = EndDate,
                TotalInstructionalDays = TotalInstructionalDays,
                Sections = _sections
            };
        }

        public SessionBuilder WithSchoolYear(SchoolYearTypeEnum schoolYearTypeEnum)
        {
            _schoolYear = (short) schoolYearTypeEnum;
            return this;
        }

        public SessionBuilder WithSections(IList<Web.Data.Entities.Section> sections)
        {
            _sections = sections;
            return this;
        }
    }
}
