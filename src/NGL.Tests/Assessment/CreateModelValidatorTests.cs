using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
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
        private CreateAssessmentModel _createAssessmentModel;
        private Web.Data.Entities.Assessment _assessmentEntity;

        [Fact]
        public void ShouldNotHaveErrorsIfAssessmentDoesNotExist()
        {
            SetUp();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Assessment, bool>>>())
                .Returns(null as Web.Data.Entities.Assessment);

            _validator.ShouldNotHaveValidationErrorFor(a => a.AssessmentTitle, _createAssessmentModel);
        }

        [Fact]
        public void ShouldHaveErrorsIfAssessmentExists()
        {
            SetUp();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Assessment, bool>>>())
                .Returns(_assessmentEntity);

            _validator.ShouldHaveValidationErrorFor(a => a.AssessmentTitle, _createAssessmentModel);
        }

        private void SetUp()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _validator = new CreateModelValidator(_genericRepository);

            _createAssessmentModel = new CreateAssessmentModelBuilder().Build();

            _assessmentEntity = new Web.Data.Entities.Assessment()
            {
                AssessmentTitle = _createAssessmentModel.AssessmentTitle,
                AcademicSubjectDescriptorId = (int)AcademicSubjectDescriptorEnum.SocialStudies,
                AssessedGradeLevelDescriptorId = (int)GradeLevelDescriptorEnum._3rdGrade,
                AdministeredDate = new DateTime(2000, 2, 2),
                AssessmentCategoryTypeId = (int)AssessmentCategoryTypeEnum.Aptitudetest
            };
        }
    }
}
