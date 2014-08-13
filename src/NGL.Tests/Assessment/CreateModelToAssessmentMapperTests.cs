using System;
using System.Linq.Expressions;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models.Assessment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Assessment
{
    public class CreateModelToAssessmentMapperTests
    {
        private GradeLevelDescriptor _4ThGradeLevelDescriptor;
        private IGenericRepository _genericRepositoryStub;
        private Web.Data.Entities.Section _section;
        private Web.Data.Entities.Course _course;
        private IPerformanceLevelMapper _createModelToAssessmentPerformanceLevelMapperMock;
        private IAssessmentJoinMapper<AssessmentSection, Web.Data.Entities.Assessment> _createModelToAssessmentSectionMapperMock;

        [Fact]
        public void ShouldMap()
        {
            SetUp();

            var model = new CreateModelBuilder().WithGradeLevelTypeId(_4ThGradeLevelDescriptor.GradeLevelTypeId).Build();
            var entity = new CreateModelToAssessmentMapper(_genericRepositoryStub, 
                _createModelToAssessmentPerformanceLevelMapperMock, _createModelToAssessmentSectionMapperMock).Build(model);

            entity.AssessmentTitle.ShouldBe(model.AssessmentTitle);
            entity.AdministeredDate.ShouldBe(model.AdministeredDate.GetValueOrDefault());
            entity.AssessmentCategoryTypeId.ShouldBe((int) model.QuestionType.GetValueOrDefault());

            entity.AssessedGradeLevelDescriptorId.ShouldBe(_4ThGradeLevelDescriptor.GradeLevelDescriptorId);
            entity.AcademicSubjectDescriptorId.ShouldBe(_course.AcademicSubjectDescriptorId.GetValueOrDefault());
        }

        private void SetUp()
        {
            _genericRepositoryStub = Substitute.For<IGenericRepository>();
            _createModelToAssessmentPerformanceLevelMapperMock = Substitute.For<IPerformanceLevelMapper>();
            _createModelToAssessmentSectionMapperMock = Substitute.For<IAssessmentJoinMapper<AssessmentSection, Web.Data.Entities.Assessment>>();

            _section = new SectionBuilder().Build();
            _course = new CourseBuilder().Build();

            _4ThGradeLevelDescriptor = new GradeLevelDescriptor
            {
                GradeLevelDescriptorId = 99,
                GradeLevelTypeId = 100
            };

            _genericRepositoryStub.Get(Arg.Any<GradeLevelTypeDescriptorQuery>())
                                .Returns(_4ThGradeLevelDescriptor);
            _genericRepositoryStub.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                                .Returns(_section);
            _genericRepositoryStub.Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                                .Returns(_course);
        }
    }
}
