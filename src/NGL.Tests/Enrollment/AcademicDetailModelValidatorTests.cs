using System;
using System.Web;
using FluentValidation.TestHelper;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelValidatorTests
    {
        private const decimal TooLongNumber = 12345678m;
        private readonly AcademicDetailModelValidator _validator;
        private readonly IGenericRepository _repository;
        private const decimal TooManyDecimals = 1.000m;
        private const int NegativeNumber = -1;

        public AcademicDetailModelValidatorTests()
        {
            _repository = Substitute.For<IGenericRepository>();
            _validator = new AcademicDetailModelValidator(_repository);
        }

        [Fact]
        public void ShouldHaveErrorsIfModelNotValidWithNulls()
        {
            var academicDetailModel = new AcademicDetailModel();

            _validator.ShouldHaveValidationErrorFor(adm => adm.Reading, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Writing, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Math, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.AnticipatedGrade, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.EntryDate, academicDetailModel);
        }

        [Fact]
        public void ShouldHaveErrorsIfStringsTooLong()
        {
            var longString = new String('a', 4001);
            _validator.ShouldHaveValidationErrorFor(adm => adm.PerformanceHistory, longString);
        }

        [Fact]
        public void ShouldHaveErrorsIfModelNotValidWithGradesOutOfRange()
        {
            var academicDetailModel = new AcademicDetailModel
            {
                Reading = TooLongNumber,
                Math = TooManyDecimals,
                Writing = NegativeNumber
            };
            _validator.ShouldHaveValidationErrorFor(adm => adm.Reading, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Writing, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Math, academicDetailModel);
        }

        [Fact]
        public void ShouldNotHaveErrorsForNonRequiredFields()
        {
            _validator.ShouldNotHaveValidationErrorFor(adm => adm.PerformanceHistory, null as string);
            _validator.ShouldNotHaveValidationErrorFor(adm => adm.PerformanceHistoryFile, null as HttpPostedFileBase);
        }

        [Fact]
        public void ShouldHaveErrorsWhenCreatingDuplicateAcademicDetailEntities()
        {
            var academicDetailModel = new AcademicDetailModel
            {
                StudentUsi = 1,
                SchoolYear = SchoolYearTypeEnum.Year1990
            };

            _repository
                .Get(Arg.Any<Web.Data.Queries.StudentAcademicDetailsByStudentUsiAndSchoolYearQuery>())
                .Returns(new StudentAcademicDetail());

            _validator.ShouldHaveValidationErrorFor(adm => adm.SchoolYear, academicDetailModel);
        }

        [Fact]
        public void ShouldNotHaveErrorsWhenCreatingNewEntity()
        {
            var academicDetailModel = new AcademicDetailModel
            {
                StudentUsi = 1,
                SchoolYear = SchoolYearTypeEnum.Year1990
            };

            _repository
               .Get(Arg.Any<Web.Data.Queries.StudentAcademicDetailsByStudentUsiAndSchoolYearQuery>())
               .Returns((StudentAcademicDetail) null);

            _validator.ShouldNotHaveValidationErrorFor(adm => adm.SchoolYear, academicDetailModel);
        }
    }
}
