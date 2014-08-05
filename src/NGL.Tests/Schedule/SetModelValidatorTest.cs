using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models.Schedule;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Schedule
{
    public class SetModelValidatorTest
    {
        private IGenericRepository _genericRepository;
        private SetModelValidator _validator;

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _validator = new SetModelValidator(_genericRepository);  
        }

        [Fact]
        public void ShouldNotGiveErrorsForValidSetModel()
        {
            Setup();
            var setModel = new SetScheduleModelBuilder().Build();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(new SectionBuilder().Build());
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(null as StudentSectionAssociation);

            _validator.ShouldNotHaveValidationErrorFor(m => m.ErrorMessage, setModel);
        }

        [Fact]
        public void ShouldGiveErrorsIfSectionDoesNotExist()
        {
            Setup();
            var setModel = new SetScheduleModelBuilder().Build();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(null as Web.Data.Entities.Section);
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(null as StudentSectionAssociation);

            _validator.ShouldHaveValidationErrorFor(m => m.ErrorMessage, setModel);
        }
        
        [Fact]
        public void ShouldGiveErrorsIfStudentSectionAssociationAlreadyExists()
        {
            Setup();
            var setModel = new SetScheduleModelBuilder().Build();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(new SectionBuilder().Build());
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(new StudentSectionAssociation());

            _validator.ShouldHaveValidationErrorFor(m => m.ErrorMessage, setModel);
        }
    }
}
