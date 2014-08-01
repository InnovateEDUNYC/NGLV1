using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NSubstitute;
using Xunit;
using CreateModel = NGL.Web.Models.Session.CreateModel;
using CreateModelValidator = NGL.Web.Models.Session.CreateModelValidator;

namespace NGL.Tests.Session
{
    public class ValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModel _sessionCreateModel;
        private CreateModelValidator _validator;

        [Fact]
        public void ShouldNotHaveErrorsIfSessionDoesNotExist()
        {
            Setup();

            _genericRepository
                .Get(Arg.Any<SessionByTermTypeAndSchoolYearQuery>())
                .Returns(null as Web.Data.Entities.Session);

            _validator.ShouldNotHaveValidationErrorFor(s => s.Term, _sessionCreateModel);
            _validator.ShouldNotHaveValidationErrorFor(s => s.SchoolYear, _sessionCreateModel);
        }


        [Fact]
        public void ShouldHaveErrorsIfSessionExists()
        {
            Setup();
            var sessionEntity = new SessionBuilder().Build();

            _genericRepository
                .Get(Arg.Any<SessionByTermTypeAndSchoolYearQuery>())
                .Returns(sessionEntity);

            _validator.ShouldHaveValidationErrorFor(s => s.Term, _sessionCreateModel);
            _validator.ShouldHaveValidationErrorFor(s => s.SchoolYear, _sessionCreateModel);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _sessionCreateModel = new CreateSessionModelBuilder().Build();
            _validator = new CreateModelValidator(_genericRepository);
        }

    }
}
