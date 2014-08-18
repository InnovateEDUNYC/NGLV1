using System.Linq;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentToAssessmentIndexModelMapper : MapperBase<Data.Entities.Assessment, IndexModel>
    {
        public override void Map(Data.Entities.Assessment source, IndexModel target)
        {
            target.id = source.AssessmentIdentity;
            target.AssessmentTitle = source.AssessmentTitle;
            target.Date = source.AdministeredDate.ToShortDateString();
            target.CCSS = source.AssessmentLearningStandards.First().LearningStandard.Description;
            target.SectionName = source.AssessmentSections.First().Section.UniqueSectionCode;
            target.SessionName = source.AssessmentSections.First().Section.Session.SessionName;
        }
    }
}