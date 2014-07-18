using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class StudentAcademicDetailMapperTests
    {
        readonly MapperBase<AcademicDetailModel, StudentAcademicDetail> _mapper = new AdademicDetailModelToAcademicDetailMapper();

        [Fact]
        public void ShouldMapAcademicDetailModelToAcademicDetailEntity()
        {
            var mockedFile = Substitute.For<HttpPostedFileBase>();
            var academicDetailModel = new AcademicDetailModel
            {
                Reading = 75.2m,
                Writing = 60m,
                Math = 78m,
                SchoolYear = SchoolYearTypeEnum.Year2014,
                AnticipatedGrade = GradeLevelTypeEnum._7thGrade,
                PerformanceHistory = "Not the best writer",
                PerformanceHistoryFile = mockedFile
            };

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = 123;
                    adm.PerformanceHistoryFileUrl = "http://example.com/phf.pdf";
                });

            academicDetailEntity.StudentUSI.ShouldBe(123);
            academicDetailEntity.ReadingScore.ShouldBe(75.2m);
            academicDetailEntity.WritingScore.ShouldBe(60m);
            academicDetailEntity.MathScore.ShouldBe(78m);
            academicDetailEntity.SchoolYear.ShouldBe((short)SchoolYearTypeEnum.Year2014);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)GradeLevelTypeEnum._7thGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe("Not the best writer");
            academicDetailEntity.PerformanceHistoryFileUrl.ShouldBe("http://example.com/phf.pdf");
        }

        [Fact]
        public void ShouldMapAcademicDetailModelWithoutPerformanceHistoryToAcademicDetailEntity()
        {
            var academicDetailModel = new AcademicDetailModel
            {
                Reading = 75.2m,
                Writing = 60m,
                Math = 78m,
                SchoolYear = SchoolYearTypeEnum.Year2014,
                AnticipatedGrade = GradeLevelTypeEnum._7thGrade,
            };

            var academicDetailEntity = _mapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = 123;
                });

            academicDetailEntity.StudentUSI.ShouldBe(123);
            academicDetailEntity.ReadingScore.ShouldBe(75.2m);
            academicDetailEntity.WritingScore.ShouldBe(60m);
            academicDetailEntity.MathScore.ShouldBe(78m);
            academicDetailEntity.SchoolYear.ShouldBe((short)SchoolYearTypeEnum.Year2014);
            academicDetailEntity.GradeLevelTypeId.ShouldBe((int)GradeLevelTypeEnum._7thGrade);
            academicDetailEntity.PerfomanceHistory.ShouldBe(null);
            academicDetailEntity.PerformanceHistoryFileUrl.ShouldBe(null);
        }


    }
}