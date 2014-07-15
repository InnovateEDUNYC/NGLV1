using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.ClassPeriod
{
    public class CreateModelToClassPeriodMapper : MapperBase<CreateModel, Data.Entities.ClassPeriod>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToClassPeriodMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.ClassPeriod target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.ClassPeriodName = source.ClassPeriodName;
        }
    }
}