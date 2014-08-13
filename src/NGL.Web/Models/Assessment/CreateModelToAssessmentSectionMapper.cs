using System.Collections.ObjectModel;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelToAssessmentSectionMapper : IAssessmentJoinMapper<AssessmentSection, Data.Entities.Assessment>
    {
        private readonly IGenericRepository _genericRepository;
        private Data.Entities.Assessment _assessment;

        public CreateModelToAssessmentSectionMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public AssessmentSection Build(CreateModel source, Data.Entities.Assessment assessment)
        {
            _assessment = assessment;
            if (assessment.AssessmentSections.IsNullOrEmpty())
                assessment.AssessmentSections = new Collection<AssessmentSection>();

            var assessmentSection = Build(source);

            assessment.AssessmentSections.Add(assessmentSection);
            return assessmentSection;
        }

        private AssessmentSection Build(CreateModel source)
        {
            var target = new AssessmentSection();
            MapAssessment(target);
            MapSection(source, target);
            return target;
        }

        private void MapAssessment(AssessmentSection target)
        {
            target.AssessmentTitle = _assessment.AssessmentTitle;
            target.AssessedGradeLevelDescriptorId = _assessment.AssessedGradeLevelDescriptorId;
            target.AcademicSubjectDescriptorId = _assessment.AcademicSubjectDescriptorId;
            target.Version = _assessment.Version;
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