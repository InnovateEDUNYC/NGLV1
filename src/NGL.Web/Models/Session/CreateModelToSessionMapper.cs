using System;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Session
{
    public class CreateModelToSessionMapper : IMapper<CreateModel, Data.Entities.Session>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToSessionMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void Map(CreateModel source, Data.Entities.Session target)
        {
            target.SchoolId = _schoolRepository.GetSchool().SchoolId;
            target.TermTypeId = (int) source.Term.GetValueOrDefault();
            target.SchoolYear = (short) source.SchoolYear;
            target.BeginDate = (DateTime) source.BeginDate.GetValueOrDefault();
            target.EndDate = (DateTime) source.EndDate.GetValueOrDefault();
            target.SessionName = string.Empty;
            target.TotalInstructionalDays = (int) source.TotalInstructionalDays;
        }
    }
}