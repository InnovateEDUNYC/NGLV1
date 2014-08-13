using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentSectionMapper : MapperBase<CreateModel, AssessmentSection>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentSectionMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, AssessmentSection target)
        {
            MapPartOfAssessment(source, target);
            MapSection(source, target);
        }

        private void MapPartOfAssessment(CreateModel source, AssessmentSection target)
        {
            target.AssessmentTitle = source.AssessmentTitle;

            var query = new GradeLevelTypeDescriptorQuery((int) source.GradeLevel.GetValueOrDefault());

            var assessedGradeLevelDescriptor = _genericRepository.Get(query);
            target.AssessedGradeLevelDescriptorId =
                assessedGradeLevelDescriptor.GradeLevelDescriptorId;
        }

        private void MapSection(CreateModel source, AssessmentSection target)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == source.SectionId);

            target.SchoolId = section.SchoolId;
            target.SchoolYear = section.SchoolYear;
            target.TermTypeId = section.TermTypeId;
            target.LocalCourseCode = section.LocalCourseCode;
            target.ClassroomIdentificationCode = section.ClassroomIdentificationCode;
            target.ClassPeriodName = section.ClassPeriodName;
        }
    }
}