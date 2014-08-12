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
            target.StudentResults = new List<EnterResultsStudentModel>();
            foreach (var student in students)      
            {
                var studentAssessment = new StudentAssessment();
                if (!student.StudentAssessments.IsNullOrEmpty())
                    studentAssessment = student.StudentAssessments.FirstOrDefault(
                        a => a.Assessment.AssessmentIdentity == source.AssessmentIdentity);
                else
                {
                    studentAssessment.Student = student;
                }
                target.StudentResults.Add(_studentAssessmentToEnterResultsStudentModelMapper.Build(studentAssessment));
            }
        }
    }
}