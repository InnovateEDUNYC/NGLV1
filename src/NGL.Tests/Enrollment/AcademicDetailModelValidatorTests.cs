using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentValidation.TestHelper;
using NGL.Web.Controllers;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelValidatorTests
    {
        private AcademicDetailModelValidator _validator;
        private IGenericRepository _repository;

        public AcademicDetailModelValidatorTests()
        {
            _repository = Substitute.For<IGenericRepository>();
            _validator = new AcademicDetailModelValidator(_repository);
        }

        [Fact]
        public void ShouldHaveErrorsIfModelNotValidWithNulls()
        {
            var academicDetailModel = new AcademicDetailModel()
            {
                Reading = null,
                Writing = null,
                Math = null,
                AnticipatedGrade = null,
            };

            _validator.ShouldHaveValidationErrorFor(adm => adm.Reading, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Writing, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.Math, academicDetailModel);
            _validator.ShouldHaveValidationErrorFor(adm => adm.AnticipatedGrade, academicDetailModel);
        }

        [Fact]
        public void ShouldHaveErrorsIfStringsTooLong()
        {
            var longString = createStringOfLength(4001);
            _validator.ShouldHaveValidationErrorFor(adm => adm.PerformanceHistory, longString);
        }

        private String createStringOfLength(int length)
        {
            var retString = "";
            for (int i = 0; i < length; i++)
            {
                retString += "a";
            }

            return retString;
        }

        [Fact]
        public void ShouldHaveErrorsIfModelNotValidWithGradesOutOfRange()
        {
            var academicDetailModel = new AcademicDetailModel()
            {
                Reading = 12345678m, //Too long
                Math = 1.000m, //Too many decimal places
                Writing = -1 //No negatives
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
    }
}
