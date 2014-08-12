using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentMapper : MapperBase<CreateAssessmentModel, Data.Entities.Assessment>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IPerformanceLevelMapper _createModelToAssessmentPerformanceLevelMapper;
        private readonly ICreateModelToAssessmentSectionMapper _createModelToCreateModelToAssessmentSectionMapper;
        private readonly ICreateModelToAssessmentLearningStandardMapper _createModelToCreateModelToAssessmentLearningStandardMapper;

        public CreateModelToAssessmentMapper(IGenericRepository genericRepository, 
            IPerformanceLevelMapper createModelToAssessmentPerformanceLevelMapper, 
            ICreateModelToAssessmentSectionMapper createModelToCreateModelToAssessmentSectionMapper, ICreateModelToAssessmentLearningStandardMapper createModelToCreateModelToAssessmentLearningStandardMapper)
        {
            _genericRepository = genericRepository;
            _createModelToAssessmentPerformanceLevelMapper = createModelToAssessmentPerformanceLevelMapper;
            _createModelToCreateModelToAssessmentSectionMapper = createModelToCreateModelToAssessmentSectionMapper;
            _createModelToCreateModelToAssessmentLearningStandardMapper = createModelToCreateModelToAssessmentLearningStandardMapper;
        }

        public override void Map(CreateAssessmentModel source, Data.Entities.Assessment target)
        {
            target.AssessmentTitle = source.AssessmentTitle;
            target.AdministeredDate = source.AdministeredDate.GetValueOrDefault();
            target.AssessmentCategoryTypeId = (int) source.QuestionType.GetValueOrDefault();
            
            MapAcademicSubjectFromCourse(source, target);
            MapGradeLevelTypeFromDescriptor(source, target);
            MapAssessmentPerformanceLevels(source, target);
            MapAssessmentSections(source, target);
            MapAssessmentLearningStandards(source, target);

        }

        private void MapAcademicSubjectFromCourse(CreateModel source, Data.Entities.Assessment target)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == source.SectionId);
            var course = _genericRepository.Get<Data.Entities.Course>(c => c.CourseCode == section.LocalCourseCode);

            target.AcademicSubjectDescriptorId = course.AcademicSubjectDescriptorId.GetValueOrDefault();
        }

        private void MapGradeLevelTypeFromDescriptor(CreateModel source, Data.Entities.Assessment target)
        {
            var query = new GradeLevelTypeDescriptorQuery((int) source.GradeLevel.GetValueOrDefault());
            target.AssessedGradeLevelDescriptorId = _genericRepository.Get(query).GradeLevelDescriptorId;
        }

        private void MapAssessmentPerformanceLevels(CreateModel source, Data.Entities.Assessment target)
        {
            _createModelToAssessmentPerformanceLevelMapper
                .BuildWithPerformanceLevel(source, target, PerformanceLevelDescriptorEnum.NearMastery);
            _createModelToAssessmentPerformanceLevelMapper
                .BuildWithPerformanceLevel(source, target, PerformanceLevelDescriptorEnum.Mastery);
        }

        private void MapAssessmentSections(CreateModel source, Data.Entities.Assessment target)
        {
            _createModelToCreateModelToAssessmentSectionMapper.Build(source, target);
        }

        private void MapAssessmentLearningStandards(CreateModel source, Data.Entities.Assessment assessment)
        {
            _createModelToCreateModelToAssessmentLearningStandardMapper.Build(source, assessment);
        }
    }
}