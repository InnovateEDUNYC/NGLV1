using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class CreateModelValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModelValidator _validator;
        private CreateModel _createModel;
        private Web.Data.Entities.Assessment _assessmentEntity;

        [Fact]
        public void ShouldNotHaveErrorsIfAssessmentDoesNotExist()
        {
            SetUp();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Assessment, bool>>>())
                .Returns(null as Web.Data.Entities.Assessment);

            _validator.ShouldNotHaveValidationErrorFor(a => a.AssessmentTitle, _createModel);
        }

        [Fact]
        public void ShouldHaveErrorsIfAssessmentExists()
        {
            SetUp();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Assessment, bool>>>())
                .Returns(_assessmentEntity);

            _validator.ShouldHaveValidationErrorFor(a => a.AssessmentTitle, _createModel);
        }

        private void SetUp()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _validator = new CreateModelValidator(_genericRepository);

            _createModel = new CreateModelBuilder().Build();

            _assessmentEntity = new Web.Data.Entities.Assessment()
            {
                AssessmentTitle = _createModel.AssessmentTitle,
                AcademicSubjectDescriptorId = (int)AcademicSubjectDescriptorEnum.SocialStudies,
                AssessedGradeLevelDescriptorId = (int)GradeLevelDescriptorEnum._3rdGrade,
                AdministeredDate = new DateTime(2000, 2, 2),
                AssessmentCategoryTypeId = (int)AssessmentCategoryTypeEnum.Aptitudetest
            };
        }
    }
}
