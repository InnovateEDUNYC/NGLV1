using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class SectionBuilder
    {
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private const int TermTypeId = (int) TermTypeEnum.FallSemester;
        private const string ClassPeriodName = "4";
        private const string ClassroomIdentificationCode = "BKL200";
        private const string LocalCourseCode = "PHYS200";
        private const string UniqueSectionCode = "PHYS200 - 301";
        private const int SequenceOfCourse = 13;

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
