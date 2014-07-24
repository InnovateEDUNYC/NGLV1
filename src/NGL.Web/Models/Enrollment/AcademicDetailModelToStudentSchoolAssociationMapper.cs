using System;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelToStudentSchoolAssociationMapper : MapperBase<AcademicDetailModel, StudentSchoolAssociation>
    {
        private ISchoolRepository _schoolRepository;
        private IGenericRepository _genericRepository;

        public AcademicDetailModelToStudentSchoolAssociationMapper(ISchoolRepository schoolRepository, IGenericRepository genericRepository)
        {
            _schoolRepository = schoolRepository;
            _genericRepository = genericRepository;
        }
        public override void Map(AcademicDetailModel source, StudentSchoolAssociation target)
        {
            target.StudentUSI = source.StudentUsi;
            target.EntryDate = (DateTime) source.EntryDate;
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            var gradeLevelTypeId = (int) source.AnticipatedGrade;

            var gradeLevelDescriptor = _genericRepository.Get<GradeLevelDescriptor>(g => g.GradeLevelTypeId == gradeLevelTypeId);
            target.EntryGradeLevelDescriptorId = gradeLevelDescriptor.GradeLevelDescriptorId;
        }
    }
}