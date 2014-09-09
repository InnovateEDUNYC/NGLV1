using System;
using System.Linq.Expressions;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelToStudentSchoolAssociationMapperTest
    {
        private const int GradeLevelDescriptorId = 125;
        private const int SchoolId = 123;
        private readonly ISchoolRepository _schoolRepository;
        private readonly AcademicDetailModelToStudentSchoolAssociationMapper _mapper;
        private readonly IGenericRepository _genericRepository;

        public AcademicDetailModelToStudentSchoolAssociationMapperTest()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _genericRepository = Substitute.For<IGenericRepository>();
             _mapper = new AcademicDetailModelToStudentSchoolAssociationMapper(_schoolRepository, _genericRepository);
        }

        [Fact]
        public void ShouldMapAcademicDetailModelToStudentSchoolAssociation()
        {
            var academicDetailModel =
                CreateAcademicDetailModelFactory.CreateAcademicDetailModelWithoutPerformanceHistory();

            SetUpStubs();

            var association = _mapper.Build(academicDetailModel);

            association.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            association.EntryDate.ShouldBe((DateTime)academicDetailModel.EntryDate);
            association.SchoolId.ShouldBe(SchoolId);
            association.EntryGradeLevelDescriptorId.ShouldBe(GradeLevelDescriptorId);
        }

        private void SetUpStubs()
        {
            _schoolRepository.GetSchool().Returns(new School {SchoolId = SchoolId});

            _genericRepository.Get(Arg.Any<Expression<Func<GradeLevelDescriptor, bool>>>())
                .Returns(new GradeLevelDescriptor {GradeLevelDescriptorId = GradeLevelDescriptorId});
        }
    }
}
