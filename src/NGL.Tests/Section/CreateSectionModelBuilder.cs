using NGL.Web.Data.Entities;
using NGL.Web.Models.Section;

namespace NGL.Tests.Section
{
    public class CreateSectionModelBuilder
    {
        private const SchoolYearTypeEnum SchoolYear = SchoolYearTypeEnum.Year2014;
        private const TermTypeEnum TermType = TermTypeEnum.FallSemester;
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
                Term = TermType,
                Period = ClassPeriodName,
                Classroom = ClassroomIdentificationCode,
                Course = LocalCourseCode,
                UniqueSectionCode = UniqueSectionCode,
                SequenceOfCourse = SequenceOfCourse
            };
        }
    }
}