using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToCourseOfferingMapper : MapperBase<CreateModel, Data.Entities.CourseOffering>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IGenericRepository _genericRepository;

        public CreateModelToCourseOfferingMapper(ISchoolRepository schoolRepository, IGenericRepository genericRepository)
        {
            _schoolRepository = schoolRepository;
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, Data.Entities.CourseOffering target)
        {
            var session = _genericRepository.Get<Data.Entities.Session>(s => s.SessionIdentity == source.SessionId);

            target.EducationOrganizationId = _schoolRepository.GetSchool()
                .EducationOrganization.EducationOrganizationId;
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.LocalCourseCode = source.Course;
            target.CourseCode = source.Course;
            target.TermTypeId = session.TermTypeId;
            target.SchoolYear = session.SchoolYear;
        }

    }
}