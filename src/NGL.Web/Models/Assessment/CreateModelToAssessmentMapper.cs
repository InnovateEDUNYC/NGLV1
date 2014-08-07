using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentMapper : MapperBase<CreateModel, Data.Entities.Assessment>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelToAssessmentMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(CreateModel source, Data.Entities.Assessment target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AdministeredDate = source.AdministeredDate;
            target.AssessmentCategoryTypeId = (int) source.QuestionType.GetValueOrDefault();

            var gradeLevelDescriptor = _genericRepository.Get<GradeLevelDescriptor>(m => m.GradeLevelTypeId == (int)source.GradeLevel);
            target.AssessedGradeLevelDescriptorId = gradeLevelDescriptor.GradeLevelDescriptorId;
        }
    }
}