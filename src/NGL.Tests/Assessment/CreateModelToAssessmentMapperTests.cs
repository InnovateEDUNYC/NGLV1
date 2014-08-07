using System;
using System.Linq.Expressions;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class CreateModelToAssessmentMapperTests
    {

        [Fact]
        public void ShouldMap()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var _4ThGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            genericRepository.Get(Arg.Any<Expression<Func<GradeLevelDescriptor, bool>>>()).Returns(_4ThGradeLevelDescriptor);

            var model = new CreateModelBuilder().WithGradeLevelTypeId(_4ThGradeLevelDescriptor.GradeLevelTypeId).Build();
            var entity = new CreateModelToAssessmentMapper(genericRepository).Build(model);

            entity.AssessmentTitle.ShouldBe(model.AssessmentTitle);
            entity.AdministeredDate.ShouldBe(model.AdministeredDate);
            entity.AssessmentCategoryTypeId.ShouldBe((int) model.QuestionType.GetValueOrDefault());

            entity.AssessedGradeLevelDescriptorId.ShouldBe(_4ThGradeLevelDescriptor.GradeLevelDescriptorId);
        }
    }
}
