using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Section
{
    public class CreateModelToSectionMapper : MapperBase<CreateModel, Data.Entities.Section>
    {
        private IGenericRepository _genericRepository { get; set; }
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToSectionMapper(ISchoolRepository schoolRepository, IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.Section target)
        {
            var session = _genericRepository.Get<Data.Entities.Session>(s => s.SessionIdentity == source.SessionId);

            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.ClassPeriodName = source.Period;
            target.ClassroomIdentificationCode = source.Classroom;
            target.LocalCourseCode = source.Course;
            target.TermTypeId = session.TermTypeId;
            target.SchoolYear = session.SchoolYear;
            target.UniqueSectionCode = source.UniqueSectionCode;
            target.SequenceOfCourse = source.SequenceOfCourse.GetValueOrDefault();
        }
    }
}