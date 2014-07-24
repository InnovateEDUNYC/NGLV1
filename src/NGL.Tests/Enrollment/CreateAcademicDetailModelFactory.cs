using System;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Enrollment;

namespace NGL.Tests.Enrollment
{
    public static class CreateAcademicDetailModelFactory
    {
        private static readonly DateTime EntryDate = new DateTime(2014, 8, 1);
        private static readonly HttpPostedFileBase NullHttpPostedFileBase = null;
        private const decimal Reading = 75.2m;
        private const decimal Writing = 60m;
        private const decimal Math = 78m;
        private const SchoolYearTypeEnum SchoolYearTypeEnum = Web.Data.Entities.SchoolYearTypeEnum.Year2014;
        private const GradeLevelTypeEnum GradeLevelTypeEnum = Web.Data.Entities.GradeLevelTypeEnum._7thGrade;
        private const string PerformanceHistory = "Good writer";
        private const int StudentUsi = 123240;

        public static AcademicDetailModel CreateAcademicDetailModelWithPerformanceHistory()
        {
            return new AcademicDetailModel
            {
                StudentUsi = StudentUsi,
                Reading = Reading,
                Writing = Writing,
                Math = Math,
                SchoolYear = SchoolYearTypeEnum,
                AnticipatedGrade = GradeLevelTypeEnum,
                EntryDate = EntryDate,
                PerformanceHistory = PerformanceHistory,
                PerformanceHistoryFile = NullHttpPostedFileBase,
            };
        }

        public static AcademicDetailModel CreateAcademicDetailModelWithoutPerformanceHistory()
        {
            return new AcademicDetailModel
            {
                Reading = Reading,
                Writing = Writing,
                Math = Math,
                SchoolYear = SchoolYearTypeEnum,
                AnticipatedGrade = GradeLevelTypeEnum,
                EntryDate = EntryDate
            };
        }
        public static AcademicDetailModel CreateAcademicDetailModelWithGrade(GradeLevelTypeEnum grade)
        {
            return new AcademicDetailModel
            {
                StudentUsi = StudentUsi,
                EntryDate = EntryDate,
                AnticipatedGrade = grade
            };
        }
    }
}
