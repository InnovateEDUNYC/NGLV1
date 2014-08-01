using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class SectionBuilder
    {
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermTypeId = (int) TermTypeEnum.FallSemester;
        private const string ClassPeriodName = "Period 3";
        private const string ClassroomIdentificationCode = "BKL 200";
        private const string LocalCourseCode = "CHEM2090";
        private const string UniqueSectionCode = "CHEM2090 - 200";
        private const int SequenceOfCourse = 1;

        public Web.Data.Entities.Section Build()
        {
            return new Web.Data.Entities.Section
            {
                SchoolId = Constants.SchoolId,
                SchoolYear = SchoolYear,
                TermTypeId = TermTypeId,
                ClassPeriodName = ClassPeriodName,
                ClassroomIdentificationCode = ClassroomIdentificationCode,
                LocalCourseCode = LocalCourseCode,
                UniqueSectionCode = UniqueSectionCode,
                SequenceOfCourse = SequenceOfCourse
            };
        }
    }
}
