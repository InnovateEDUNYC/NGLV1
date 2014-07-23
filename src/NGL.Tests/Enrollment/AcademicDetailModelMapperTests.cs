using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelMapperTests
    {
        readonly MapperBase<AcademicDetailModel, StudentAcademicDetail> _mapper = new AdademicDetailModelToAcademicDetailMapper();

        [Fact]
        public void ShouldMapAcademicDetailModelToAcademicDetailEntity()
        {
            var academicDetailModel = AcademicDetailModelFactory.CreateAcademicDetailModelWithPerformanceHistory();

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = academicDetailModel.StudentUsi;
                    adm.PerformanceHistoryFileUrl = "http://example.com/phf.pdf";
                });

            academicDetailEntity.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            academicDetailEntity.ReadingScore.ShouldBe((decimal)academicDetailModel.Reading);
            academicDetailEntity.WritingScore.ShouldBe((decimal)academicDetailModel.Writing);
            academicDetailEntity.MathScore.ShouldBe((decimal)academicDetailModel.Math);
            academicDetailEntity.SchoolYear.ShouldBe((short)academicDetailModel.SchoolYear);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)academicDetailModel.AnticipatedGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe(academicDetailModel.PerformanceHistory);
            academicDetailEntity.PerformanceHistoryFileUrl.ShouldBe("http://example.com/phf.pdf");
        }

        [Fact]
        public void ShouldMapAcademicDetailModelWithoutPerformanceHistoryToAcademicDetailEntity()
        {
            var academicDetailModel = AcademicDetailModelFactory.CreateAcademicDetailModelWithoutPerformanceHistory();

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = academicDetailModel.StudentUsi;
                });

            academicDetailEntity.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            academicDetailEntity.ReadingScore.ShouldBe((decimal)academicDetailModel.Reading);
            academicDetailEntity.WritingScore.ShouldBe((decimal)academicDetailModel.Writing);
            academicDetailEntity.MathScore.ShouldBe((decimal)academicDetailModel.Math);
            academicDetailEntity.SchoolYear.ShouldBe((short)academicDetailModel.SchoolYear);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)academicDetailModel.AnticipatedGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe(null);
            academicDetailEntity.PerformanceHistoryFileUrl.ShouldBe(null);
        }


    }
}