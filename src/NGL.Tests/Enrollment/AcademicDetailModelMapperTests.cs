using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelMapperTests
    {
        private readonly MapperBase<AcademicDetailModel, StudentAcademicDetail> _mapper = new AcademicDetailModelToAcademicDetailMapper();

        [Fact]
        public void ShouldMapAcademicDetailModelToAcademicDetailEntity()
        {
            var academicDetailModel = CreateAcademicDetailModelFactory.CreateAcademicDetailModelWithPerformanceHistory();

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = academicDetailModel.StudentUsi;
                    adm.PerformanceHistoryFile = "http://example.com/phf.pdf";
                });

            academicDetailEntity.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            academicDetailEntity.ReadingScore.ShouldBe(academicDetailModel.Reading);
            academicDetailEntity.WritingScore.ShouldBe(academicDetailModel.Writing);
            academicDetailEntity.MathScore.ShouldBe(academicDetailModel.Math);
            academicDetailEntity.SchoolYear.ShouldBe((short)academicDetailModel.SchoolYear);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)academicDetailModel.AnticipatedGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe(academicDetailModel.PerformanceHistory);
            academicDetailEntity.PerformanceHistoryFile.ShouldBe("http://example.com/phf.pdf");
        }

        [Fact]
        public void ShouldMapAcademicDetailModelWithoutPerformanceHistoryToAcademicDetailEntity()
        {
            var academicDetailModel = CreateAcademicDetailModelFactory.CreateAcademicDetailModelWithoutPerformanceHistory();

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = academicDetailModel.StudentUsi;
                });

            academicDetailEntity.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            academicDetailEntity.ReadingScore.ShouldBe(academicDetailModel.Reading);
            academicDetailEntity.WritingScore.ShouldBe(academicDetailModel.Writing);
            academicDetailEntity.MathScore.ShouldBe(academicDetailModel.Math);
            academicDetailEntity.SchoolYear.ShouldBe((short)academicDetailModel.SchoolYear);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)academicDetailModel.AnticipatedGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe(null);
            academicDetailEntity.PerformanceHistoryFile.ShouldBe(null);
        }


    }
}