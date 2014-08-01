using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToCourseOfferingMapper : MapperBase<CreateModel, Data.Entities.CourseOffering>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToCourseOfferingMapper(IGenericRepository genericRepository, ISchoolRepository schoolRepository)
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.CourseOffering target)
        {
            target.EducationOrganizationId = _schoolRepository.GetSchool()
                .EducationOrganization.EducationOrganizationId;
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;

            target.LocalCourseCode = source.Course;

            target.Course = _genericRepository.Get<Data.Entities.Course>(
                c => c.CourseCode == source.Course);

            target.Session = _genericRepository.Get<Data.Entities.Session>(
                s => s.TermTypeId == (int) source.Term && 
                    s.SchoolYear == (short) source.SchoolYear);
        }

    }
}