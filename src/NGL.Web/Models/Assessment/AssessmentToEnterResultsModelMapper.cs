using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;

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
            var studentSectionAssociations = section.StudentSectionAssociations;
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
                    studentAssessment.AdministrationDate = source.AdministeredDate;
                }
                target.StudentResults.Add(_studentAssessmentToEnterResultsStudentModelMapper.Build(studentAssessment));
            }
        }
    }
}