using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Dates;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentToEnterResultsModelMapper : MapperBase<Data.Entities.Assessment, EnterResultsModel>
    {
        private readonly IMapper<StudentAssessment, EnterResultsStudentModel> _studentAssessmentToEnterResultsStudentModelMapper;

        public AssessmentToEnterResultsModelMapper(IMapper<StudentAssessment, EnterResultsStudentModel> studentAssessmentToEnterResultsStudentModelMapper)
        {
            _studentAssessmentToEnterResultsStudentModelMapper = studentAssessmentToEnterResultsStudentModelMapper;
        }

        public override void Map(Data.Entities.Assessment source, EnterResultsModel target)
        {
            
            var assessmentSections = source.AssessmentSections;
            var section = assessmentSections.First().Section;
            var session = section.Session;
            var administeredDate = source.AdministeredDate;
            var studentSectionAssociations = section.StudentSectionAssociations
                .Where(ssa => new DateRange(ssa.BeginDate, (DateTime)ssa.EndDate).Includes(administeredDate));
            var students = studentSectionAssociations.Select(ssa => ssa.Student).ToList();

            target.AssessmentId = source.AssessmentIdentity;
            target.Section = section.UniqueSectionCode;
            target.AssessmentTitle = source.AssessmentTitle;
            target.Session = session.SessionName;
            target.CCSS = source.AssessmentLearningStandards.First().LearningStandard.Description;
            target.AssessmentDate = source.AdministeredDate.ToShortDateString();
            target.StudentResults = new List<EnterResultsStudentModel>();

            if (source.StudentAssessments.IsNullOrEmpty())
            {
                // create new
                target.StudentResults = students.Select(s => new EnterResultsStudentModel
                {
                    StudentUsi = s.StudentUSI,
                    Name = s.FirstName + " " + s.LastSurname
                }).ToList();
            }
            else
            {
                target.StudentResults =
                    source.StudentAssessments.Select(sa => _studentAssessmentToEnterResultsStudentModelMapper.Build(sa))
                        .ToList();
            }
        }
    }
}