﻿using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Tests.Course;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;
using NSubstitute;
using Xunit;
using CreateModel = NGL.Web.Models.Course.CreateModel;

namespace NGL.Tests.ParentCourse
{
    public class ValidatorTests
    {
        private CreateModel _courseCreateModel;
        private IGenericRepository _genericRepository;
        private CreateModelValidator _validator;

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _courseCreateModel = new CreateCourseModelBuilder().Build();
            _validator = new CreateModelValidator(new RepositoryReader<Web.Data.Entities.ParentCourse>(_genericRepository));
        }

        [Fact]
        public void ShouldNotHaveErrorsIfCourseDoesNotExist()
        {
            Setup();
          _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ParentCourse, bool>>>())
                .Returns(null as Web.Data.Entities.ParentCourse);

            _validator.ShouldNotHaveValidationErrorFor(c => c.ParentCourseCode, _courseCreateModel.CourseCode);   
        }

        [Fact]
        public void ShouldHaveErrorsIfCourseExists()
        {
            Setup();
            var parentCourseEntity = new ParentCourseBuilder().Build();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ParentCourse, bool>>>())
                .Returns(parentCourseEntity);

            _validator.ShouldHaveValidationErrorFor(c => c.ParentCourseCode, _courseCreateModel.CourseCode);
        }
    }
}
