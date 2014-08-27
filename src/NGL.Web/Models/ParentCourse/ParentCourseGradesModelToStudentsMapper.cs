using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradesModelToStudentsMapper
    {
        private ParentCourseGradeModelToParentCourseGradeMapper _parentCourseGradeModelToParentCourseGradeMapper;

        public ParentCourseGradesModelToStudentsMapper(ParentCourseGradeModelToParentCourseGradeMapper parentCourseGradeModelToParentCourseGradeMapper)
        {
            _parentCourseGradeModelToParentCourseGradeMapper = parentCourseGradeModelToParentCourseGradeMapper;
        }

        public void Map(ParentCourseGradesModel parentCourseGradesModel, List<Data.Entities.Student> studentsToBeGraded)
        {
            var parentCourseId = (Guid)parentCourseGradesModel.FindParentCourseModel.ParentCourseId;
            var sesssionId = (int) parentCourseGradesModel.FindParentCourseModel.SessionId;

            foreach (var student in studentsToBeGraded)
            {
                if (!student.ParentCourseGrades.IsNullOrEmpty() &&
                    student.ParentCourseGrades.Any(pcg => pcg.ParentCourseId == parentCourseId && pcg.Session.SessionIdentity == sesssionId ))
                {

                    var parentCourseGrade = student.ParentCourseGrades.FirstOrDefault( p =>
                            p.ParentCourseId == parentCourseGradesModel.FindParentCourseModel.ParentCourseId &&
                            p.Session.SessionIdentity == parentCourseGradesModel.FindParentCourseModel.SessionId);

                    _parentCourseGradeModelToParentCourseGradeMapper.Map(parentCourseGradesModel, student.StudentUSI, parentCourseGrade);

                }
                else
                {
                    var parentCourseGradeForStudent = _parentCourseGradeModelToParentCourseGradeMapper.Build(parentCourseGradesModel, student.StudentUSI);
                    student.ParentCourseGrades.Add(parentCourseGradeForStudent);
                }
            }
        }
    }
}