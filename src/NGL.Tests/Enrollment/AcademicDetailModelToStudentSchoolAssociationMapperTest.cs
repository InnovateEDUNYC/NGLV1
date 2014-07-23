using System;
using System.Linq.Expressions;
using System.Web.Compilation;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using NSubstitute.Core.Arguments;
using Shouldly;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class AcademicDetailModelToStudentSchoolAssociationMapperTest
    {
        private ISchoolRepository _schoolRepository;
        private AcademicDetailModelToStudentSchoolAssociationMapper _mapper;
        private IGenericRepository _genericRepository;

        public AcademicDetailModelToStudentSchoolAssociationMapperTest()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _genericRepository = Substitute.For<IGenericRepository>();
             _mapper = new AcademicDetailModelToStudentSchoolAssociationMapper(_schoolRepository, _genericRepository);
        }

        [Fact]
        public void ShouldMapAcademicDetailModelToStudentSchoolAssociation()
        {
            var academicDetailModel = new AcademicDetailModel()
            {
                StudentUsi = 9999,
                EntryDate = new DateTime(2014,12,12),
                AnticipatedGrade = GradeLevelTypeEnum._4thGrade
            };

            _schoolRepository.GetSchool().Returns(new School{SchoolId = 123});

            _genericRepository.Get<GradeLevelDescriptor>(Arg.Any<Expression<Func<GradeLevelDescriptor, bool>>>()).Returns(new GradeLevelDescriptor { GradeLevelDescriptorId = 125 });

            var association = _mapper.Build(academicDetailModel);

            association.StudentUSI.ShouldBe(academicDetailModel.StudentUsi);
            association.EntryDate.ShouldBe((DateTime)academicDetailModel.EntryDate);
            association.SchoolId.ShouldBe(123);
            association.EntryGradeLevelDescriptorId.ShouldBe(125);
        }
    }
}
