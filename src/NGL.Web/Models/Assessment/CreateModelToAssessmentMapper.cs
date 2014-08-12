using Microsoft.WindowsAzure.Storage.Table;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

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
            target.AdministeredDate = source.AdministeredDate.GetValueOrDefault();
            target.AssessmentCategoryTypeId = (int) source.QuestionType.GetValueOrDefault();
            
            GetAcademicSubjectFromCourse(source, target);

            var query = new GradeLevelTypeDescriptorQuery((int) source.GradeLevel.GetValueOrDefault());

            target.AssessedGradeLevelDescriptorId = _genericRepository.Get(query).GradeLevelDescriptorId;
        }

        private void GetAcademicSubjectFromCourse(CreateModel source, Data.Entities.Assessment target)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == source.SectionId);
            var course = _genericRepository.Get<Data.Entities.Course>(c => c.CourseCode == section.LocalCourseCode);

            target.AcademicSubjectDescriptorId = course.AcademicSubjectDescriptorId.GetValueOrDefault();
        }
    }
}