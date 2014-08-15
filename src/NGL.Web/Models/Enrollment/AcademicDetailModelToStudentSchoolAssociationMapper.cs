using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelToStudentSchoolAssociationMapper : MapperBase<AcademicDetailModel, StudentSchoolAssociation>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IGenericRepository _genericRepository;

        public AcademicDetailModelToStudentSchoolAssociationMapper(ISchoolRepository schoolRepository, IGenericRepository genericRepository)
        {
            _schoolRepository = schoolRepository;
            _genericRepository = genericRepository;
        }
        public override void Map(AcademicDetailModel source, StudentSchoolAssociation target)
        {
            target.StudentUSI = source.StudentUsi;
            target.EntryDate = source.EntryDate.GetValueOrDefault();
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            var gradeLevelTypeId = (int) source.AnticipatedGrade.GetValueOrDefault();

            var gradeLevelDescriptor = _genericRepository.Get<GradeLevelDescriptor>(g => g.GradeLevelTypeId == gradeLevelTypeId);
            target.EntryGradeLevelDescriptorId = gradeLevelDescriptor.GradeLevelDescriptorId;
        }
    }
}