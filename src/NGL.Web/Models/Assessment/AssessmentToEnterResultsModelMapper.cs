using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Models.Assessment
{
    public class AssessmentToEnterResultsModelMapper : MapperBase<Data.Entities.Assessment, EnterResultsModel>
    {
        private IMapper<Data.Entities.Student, EnterResultsStudentModel> _studentToEnterResultsStudentModelMapper;

        public AssessmentToEnterResultsModelMapper(IMapper<Data.Entities.Student, EnterResultsStudentModel> studentToEnterResultsStudentModelMapper)
        {
            _studentToEnterResultsStudentModelMapper = studentToEnterResultsStudentModelMapper;
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
            target.Students = new List<EnterResultsStudentModel>();
            foreach (var student in students)
            {
                target.Students.Add(_studentToEnterResultsStudentModelMapper.Build(student));
            }
        }
    }
}