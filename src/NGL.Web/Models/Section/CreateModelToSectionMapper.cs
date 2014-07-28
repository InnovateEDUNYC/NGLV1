using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToSectionMapper : MapperBase<CreateModel, Data.Entities.Section>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToSectionMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.Section target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.SchoolYear = source.SchoolYear;
            target.TermTypeId = source.TermTypeId;
            target.ClassPeriodName = source.ClassPeriodName;
            target.ClassroomIdentificationCode = source.ClassroomIdentificationCode;
            target.LocalCourseCode = source.LocalCourseCode;
            target.UniqueSectionCode = source.UniqueSectionCode;
            target.SequenceOfCourse = source.SequenceOfCourse;
        }
    }
}