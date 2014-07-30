using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToSectionMapper : MapperBase<CreateModel, Data.Entities.Section>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper<CreateModel, Data.Entities.CourseOffering> _createModelToCourseOfferingMapper;

        public CreateModelToSectionMapper(ISchoolRepository schoolRepository, IMapper<CreateModel, Data.Entities.CourseOffering> createModelToCourseOfferingMapper)
        {
            _schoolRepository = schoolRepository;
            _createModelToCourseOfferingMapper = createModelToCourseOfferingMapper;
        }

        public override void Map(CreateModel source, Data.Entities.Section target)
        {
            var courseOffering = _createModelToCourseOfferingMapper.Build(source);
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.SchoolYear = (short) source.SchoolYear;
            target.TermTypeId = (int) source.Term;
            target.ClassPeriodName = source.Period;
            target.ClassroomIdentificationCode = source.Classroom;
            target.CourseOffering = courseOffering;
            target.UniqueSectionCode = source.UniqueSectionCode;
            target.SequenceOfCourse = source.SequenceOfCourse;
        }
    }
}