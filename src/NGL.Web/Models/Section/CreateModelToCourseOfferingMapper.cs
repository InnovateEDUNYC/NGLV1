using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToCourseOfferingMapper : MapperBase<CreateModel, Data.Entities.CourseOffering>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToCourseOfferingMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.CourseOffering target)
        {
            target.EducationOrganizationId = _schoolRepository.GetSchool()
                .EducationOrganization.EducationOrganizationId;
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.LocalCourseCode = source.Course;
            target.CourseCode = source.Course;
            target.TermTypeId = source.Term;
            target.SchoolYear = source.SchoolYear;
        }

    }
}