using System;
using System.Linq.Expressions;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Schedule
{
    public class SetModelToStudentSectionAssociationMapperTests
    {
        private IMapper<SetModel, StudentSectionAssociation> _mapper;
        private Web.Data.Entities.Section _section;
        private School _school;

        private void SetUp()
        {
            _section = new SectionBuilder().Build();
            var genericRepositoryStub = Substitute.For<IGenericRepository>();
            genericRepositoryStub.Get(Arg.Any<Expression<Func<Web.Data.Entities.Section, bool>>>()).Returns(_section);

            var schoolRepository = Substitute.For<ISchoolRepository>();
            _school = new SchoolBuilder().Build();
            schoolRepository.GetSchool().Returns(_school);

            _mapper = new SetModelToStudentSectionAssociationMapper(genericRepositoryStub, schoolRepository);
        }

        [Fact]
        public void ShouldMapSetModelToStudentSectionAssociation()
        {
            SetUp();
            var setModel = new SetScheduleModelBuilder().Build();
            var studentSectionAssociation = _mapper.Build(setModel);

            studentSectionAssociation.BeginDate.ShouldBe(setModel.BeginDate);
            studentSectionAssociation.EndDate.ShouldBe(setModel.EndDate);
            studentSectionAssociation.StudentUSI.ShouldBe(setModel.StudentUsi);
            studentSectionAssociation.SchoolYear.ShouldBe(_section.SchoolYear);
            studentSectionAssociation.TermTypeId.ShouldBe(_section.TermTypeId);
            studentSectionAssociation.LocalCourseCode.ShouldBe(_section.LocalCourseCode);
            studentSectionAssociation.ClassPeriodName.ShouldBe(_section.ClassPeriodName);
            studentSectionAssociation.ClassroomIdentificationCode.ShouldBe(_section.ClassroomIdentificationCode);
            studentSectionAssociation.SchoolId.ShouldBe(_school.SchoolId);



        }

    }
}
