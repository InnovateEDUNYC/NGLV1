using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NSubstitute;
using Xunit;
using CreateModel = NGL.Web.Models.Session.CreateModel;
using CreateModelValidator = NGL.Web.Models.Session.CreateModelValidator;

namespace NGL.Tests.Session
{
    public class ValidatorTests
    {

        [Fact]
        public void ShouldReturnTrueIfSessionDoesNotExist()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var sessionCreateModel = new CreateModel
            {
                Term = TermTypeEnum.FallSemester,
                SchoolYear = SchoolYearTypeEnum.Year2014,
                BeginDate = DateTime.Today,
                EndDate = DateTime.Today,
                TotalInstructionalDays = 100
            };

            var validator = new CreateModelValidator(genericRepository);

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Session, bool>>>())
                .Returns(null as Web.Data.Entities.Session);

            validator.ShouldNotHaveValidationErrorFor(s => s.Term, sessionCreateModel);
            validator.ShouldNotHaveValidationErrorFor(s => s.SchoolYear, sessionCreateModel);
        }


        [Fact]
        public void ShouldReturnFalseIfSessionExists()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var sessionCreateModel = new CreateModel
            {
                Term = TermTypeEnum.FallSemester,
                SchoolYear = SchoolYearTypeEnum.Year2014,
                BeginDate = DateTime.Today,
                EndDate = DateTime.Today,
                TotalInstructionalDays = 100
            };

            var validator = new CreateModelValidator(genericRepository);

            var sessionEntity = new Web.Data.Entities.Session
            {
                TermTypeId = (int) TermTypeEnum.FallSemester,
                SchoolYear = (short) SchoolYearTypeEnum.Year2014,
                BeginDate = DateTime.Today,
                EndDate = DateTime.Today,
                TotalInstructionalDays = 100
            };

            genericRepository
                .Get(Arg.Any<Web.Data.Queries.SessionByTermTypeAndSchoolYearQuery>())
                .Returns(sessionEntity);

            validator.ShouldHaveValidationErrorFor(s => s.Term, sessionCreateModel);
            validator.ShouldHaveValidationErrorFor(s => s.SchoolYear, sessionCreateModel);
        }


    }
}
