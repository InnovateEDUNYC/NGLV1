using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Builders
{
    public class EditAcademicDetailsModelBuilder
    {
        private readonly decimal? _mathScore = 30m;
        private const string PerformanceHistory = "Great student";
        private readonly decimal? _readingScore = 40m;
        private const int SchoolYear = (int) SchoolYearTypeEnum.Year2014;
        private readonly decimal? _writingScore = 50m;

        public EditAcademicDetailModel Build()
        {
            return new EditAcademicDetailModel
            {
                MathScore = _mathScore,
                PerformanceHistory = PerformanceHistory,
                ReadingScore = _readingScore,
                SchoolYear = SchoolYear,
                WritingScore = _writingScore
            };
        }
    }
}
