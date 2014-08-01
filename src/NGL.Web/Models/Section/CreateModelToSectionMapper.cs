using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToSectionMapper : MapperBase<CreateModel, Data.Entities.Section>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper<CreateModel, Data.Entities.CourseOffering> _createModelToCourseOfferingMapper;

        public CreateModelToSectionMapper(IGenericRepository genericRepository, 
            ISchoolRepository schoolRepository, IMapper<CreateModel, 
            Data.Entities.CourseOffering> createModelToCourseOfferingMapper)
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
            _createModelToCourseOfferingMapper = createModelToCourseOfferingMapper;
        }

        public override void Map(CreateModel source, Data.Entities.Section target)
        {
            var courseOffering = _genericRepository.Get<Data.Entities.CourseOffering>(
                c => c.LocalCourseCode == source.Course) ?? _createModelToCourseOfferingMapper.Build(source);

            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.ClassPeriodName = source.Period;
            target.ClassroomIdentificationCode = source.Classroom;
            target.CourseOffering = courseOffering;
            target.UniqueSectionCode = source.UniqueSectionCode;
            target.SequenceOfCourse = source.SequenceOfCourse;
        }
    }
}