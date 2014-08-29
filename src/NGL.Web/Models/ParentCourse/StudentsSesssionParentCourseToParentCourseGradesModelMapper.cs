using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.ParentCourse
{
    public class StudentsSesssionParentCourseToParentCourseGradesModelMapper 
    {
        private readonly IMapper<Data.Entities.Session, FindParentCourseModel> _sectionToFindParentCourseModelMapper;
        private readonly IMapper<ParentCourseGrade, GradeModel> _parentCourseGradeToGradeModelMapper;
        private readonly IMapper<Data.Entities.Student, GradeModel> _studentToGradeModelMapper;

        public StudentsSesssionParentCourseToParentCourseGradesModelMapper(IMapper<Data.Entities.Session, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Data.Entities.Student, GradeModel> studentToGradeModelMapper)
        {
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
            _parentCourseGradeToGradeModelMapper = parentCourseGradeToGradeModelMapper;
            _studentToGradeModelMapper = studentToGradeModelMapper;
        }

        public ParentCourseGradesModel Build(List<Data.Entities.Student> students, Data.Entities.Session session, Data.Entities.ParentCourse parentCourse)
        {

            var findParentCourseModel = _sectionToFindParentCourseModelMapper.Build(session, t =>
            {
                t.ParentCourse = parentCourse.ParentCourseCode +" - "+ parentCourse.ParentCourseTitle;
                t.ParentCourseId = parentCourse.Id;
            });

            var grades = students.SelectMany(s => s.ParentCourseGrades);

            var parentGradesModelList = grades.Select(g => _parentCourseGradeToGradeModelMapper.Build(g)).ToList();
            var studentsInParentCourseWithoutGrades = students.Where(s => s.ParentCourseGrades.IsNullOrEmpty()).ToList();

            parentGradesModelList = parentGradesModelList.Concat(studentsInParentCourseWithoutGrades.Select(s => _studentToGradeModelMapper.Build(s))).ToList();


           var parentCourseGradesModel = new ParentCourseGradesModel();

            parentCourseGradesModel.FindParentCourseModel = findParentCourseModel;
            parentCourseGradesModel.ParentGradesModelList = parentGradesModelList.ToList();

            return parentCourseGradesModel;
        }
    }
}