using NGL.Web.Data.Entities;
using NGL.Web.Models.Section;

namespace NGL.Tests.Section
{
    public class CreateSectionModelBuilder
    {
        private const short SchoolYear = (short) SchoolYearTypeEnum.Year2014;
        private const int TermTypeId = (int) TermTypeEnum.FallSemester;
        private const string ClassPeriodName = "Period 3";
        private const string ClassroomIdentificationCode = "BKL 200";
        private const string LocalCourseCode = "CHEM2090";
        private const string UniqueSectionCode = "CHEM2090 - 200";
        private const int SequenceOfCourse = 1;

        public CreateModel Build()
        {
            return new CreateModel
            {
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