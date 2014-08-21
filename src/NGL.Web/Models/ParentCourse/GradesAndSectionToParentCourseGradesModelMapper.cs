using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class GradesAndSectionToParentCourseGradesModelMapper 
    {
        private readonly IMapper<Data.Entities.Section, FindParentCourseModel> _sectionToFindParentCourseModelMapper;
        private readonly IMapper<ParentCourseGrade, GradeModel> _parentCourseGradeToGradeModelMapper;
        private readonly IMapper<Data.Entities.Student, GradeModel> _studentToGradeModelMapper;

        public GradesAndSectionToParentCourseGradesModelMapper(IMapper<Data.Entities.Section, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Data.Entities.Student, GradeModel> studentToGradeModelMapper)
        {
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
            _parentCourseGradeToGradeModelMapper = parentCourseGradeToGradeModelMapper;
            _studentToGradeModelMapper = studentToGradeModelMapper;
        }

        public ParentCourseGradesModel Build(List<ParentCourseGrade> grades, Data.Entities.Section section)
        {
            var studentsInSection = section.StudentSectionAssociations.Select(ssa => ssa.Student).ToList();

            var studentsWithGrades = grades.Select(g => g.Student).ToList();

            var studentsInSectionWithoutGrades = studentsInSection.Except(studentsWithGrades).ToList();

            var findParentCourseModel = _sectionToFindParentCourseModelMapper.Build(section);

            var parentGradesModelEnumerable = grades.Select(grade => _parentCourseGradeToGradeModelMapper.Build(grade));

            parentGradesModelEnumerable = parentGradesModelEnumerable.Concat(studentsInSectionWithoutGrades.Select(s => _studentToGradeModelMapper.Build(s)));


            var parentCourseGradesModel = new ParentCourseGradesModel();

            parentCourseGradesModel.FindParentCourseModel = findParentCourseModel;
            parentCourseGradesModel.ParentGradesModelList = parentGradesModelEnumerable.ToList();

            return parentCourseGradesModel;
        }
    }
}