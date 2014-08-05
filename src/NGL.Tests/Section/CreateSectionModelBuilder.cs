using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Section;

namespace NGL.Tests.Section
{
    public class CreateSectionModelBuilder
    {
        private const short SchoolYear = (short) SchoolYearTypeEnum.Year2014;
        private const int TermType = (int) TermTypeEnum.FallSemester;
        private static readonly string Session = 
            TermTypeEnum.FallSemester.Humanize() + " " 
            + SchoolYearTypeEnum.Year2014.Humanize();

        private const string ClassPeriodName = "Period 5";
        private const string ClassroomIdentificationCode = "Room 108";
        private string _localCourseCode = "ENGL400 - DI";
        private const string UniqueSectionCode = "Creative Writing";
        private const int SequenceOfCourse = 1;

        public CreateModel Build()
        {
            return new CreateModel
            {
                SchoolYear = SchoolYear,
                Term = TermType,
                Session = Session,
                Period = ClassPeriodName,
                Classroom = ClassroomIdentificationCode,
                Course = _localCourseCode,
                UniqueSectionCode = UniqueSectionCode,
                SequenceOfCourse = SequenceOfCourse
            };
        }

        public CreateSectionModelBuilder WithCourse(string name)
        {
            _localCourseCode = name;
            return this;
        }
    }
}