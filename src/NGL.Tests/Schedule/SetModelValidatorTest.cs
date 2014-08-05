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
        private SetModel _setModel;

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _validator = new SetModelValidator(_genericRepository);
            _setModel = new SetScheduleModelBuilder().Build();
        }

        [Fact]
        public void ShouldNotGiveErrorsForValidSetModel()
        {
            Setup();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(new SectionBuilder().Build());
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(null as StudentSectionAssociation);

            _validator.ShouldNotHaveValidationErrorFor(m => m.ErrorMessage, _setModel);
        }

        [Fact]
        public void ShouldGiveErrorsIfSectionDoesNotExist()
        {
            Setup();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(null as Web.Data.Entities.Section);
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(null as StudentSectionAssociation);

            _validator.ShouldHaveValidationErrorFor(m => m.ErrorMessage, _setModel);
        }
        
        [Fact]
        public void ShouldGiveErrorsIfStudentSectionAssociationAlreadyExists()
        {
            Setup();
            _genericRepository.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>())
                .Returns(new SectionBuilder().Build());
            _genericRepository.Get(Arg.Any<StudentSectionAssociationByPrimaryKeysQuery>())
                .Returns(new StudentSectionAssociation());

            _validator.ShouldHaveValidationErrorFor(m => m.ErrorMessage, _setModel);
        }
    }
}
