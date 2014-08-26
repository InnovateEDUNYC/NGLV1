using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class GradesAndSectionToParentCourseGradesModelMapper 
    {
        private readonly IMapper<ParentCourseGrade, FindParentCourseModel> _sectionToFindParentCourseModelMapper;
        private readonly IMapper<ParentCourseGrade, GradeModel> _parentCourseGradeToGradeModelMapper;
        private readonly IMapper<Data.Entities.Student, GradeModel> _studentToGradeModelMapper;

        public GradesAndSectionToParentCourseGradesModelMapper(IMapper<ParentCourseGrade, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Data.Entities.Student, GradeModel> studentToGradeModelMapper)
        {
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
            _parentCourseGradeToGradeModelMapper = parentCourseGradeToGradeModelMapper;
            _studentToGradeModelMapper = studentToGradeModelMapper;
        }

        public ParentCourseGradesModel Build(List<Data.Entities.Student> students)
        {
//            var studentsInSection = section.StudentSectionAssociations.Select(ssa => ssa.Student).ToList();
//
//            var studentsWithGrades = grades.Select(g => g.Student).ToList();
//
//            var studentsInSectionWithoutGrades = studentsInSection.Except(studentsWithGrades).ToList();
//
            var findParentCourseModel = _sectionToFindParentCourseModelMapper.Build(students.First().ParentCourseGrades.First());

            var grades = students.SelectMany(s => s.ParentCourseGrades);

            var parentGradesModelEnumerable = grades.Select(g => _parentCourseGradeToGradeModelMapper.Build(g));
//
//            parentGradesModelEnumerable = parentGradesModelEnumerable.Concat(studentsInSectionWithoutGrades.Select(s => _studentToGradeModelMapper.Build(s)));
//
//
           var parentCourseGradesModel = new ParentCourseGradesModel();

            parentCourseGradesModel.FindParentCourseModel = findParentCourseModel;
            parentCourseGradesModel.ParentGradesModelList = parentGradesModelEnumerable.ToList();

            return parentCourseGradesModel;
        }
    }
}