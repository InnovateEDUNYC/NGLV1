using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Schedule
{
    public class SetModelToStudentSectionAssociationMapper : MapperBase<SetModel, StudentSectionAssociation>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISchoolRepository _schoolRepository;

        public SetModelToStudentSectionAssociationMapper(IGenericRepository genericRepository, ISchoolRepository schoolRepository)
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
        }

        public override void Map(SetModel source, StudentSectionAssociation target)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == source.SectionId);
            var schoolId = _schoolRepository.GetSchool().SchoolId;
            
            target.SchoolId = schoolId;
            target.StudentUSI = source.StudentUsi;
            target.BeginDate = source.BeginDate;
            target.EndDate = source.EndDate;
            target.SchoolYear = section.SchoolYear;
            target.TermTypeId = section.TermTypeId;
            target.LocalCourseCode = section.LocalCourseCode;
            target.ClassPeriodName = section.ClassPeriodName;
            target.ClassroomIdentificationCode = section.ClassroomIdentificationCode;
        }
    }
}