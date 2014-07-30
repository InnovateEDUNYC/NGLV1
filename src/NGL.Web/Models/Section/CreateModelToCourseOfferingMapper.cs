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

            target.TermTypeId = (int) source.Term;
            target.SchoolYear = (short) source.SchoolYear;
            target.CourseCode = source.Course;
            target.LocalCourseCode = source.Course;
        }

    }
}