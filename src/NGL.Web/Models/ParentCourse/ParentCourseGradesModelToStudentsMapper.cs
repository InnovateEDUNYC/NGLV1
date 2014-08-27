using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradesModelToStudentsMapper
    {
        private ISessionRepository _sesssionRepository;

        public ParentCourseGradesModelToStudentsMapper(ISessionRepository sesssionRepository)
        {
            _sesssionRepository = sesssionRepository;
        }

        public void Map(ParentCourseGradesModel parentCourseGradesModel, List<Data.Entities.Student> studentsToBeGraded)
        {
            var session = _sesssionRepository.GetById((int)parentCourseGradesModel.FindParentCourseModel.SessionId);
            var parentCourseId = (Guid)parentCourseGradesModel.FindParentCourseModel.ParentCourseId;
            var parentCourseGradesModelList = parentCourseGradesModel.ParentGradesModelList;

            foreach (var student in studentsToBeGraded)
            {
                if (!student.ParentCourseGrades.IsNullOrEmpty() ||
                    student.ParentCourseGrades.Any(pcg => pcg.ParentCourseId == parentCourseId))
                {
                    UpdateParentCourseGradeForStudent(student, parentCourseId, parentCourseGradesModelList);
                }
                else
                {
                    CreateNewParentCourseGradeForStudent(parentCourseGradesModelList, student, parentCourseId, session);
                }
            }
        }

        private void UpdateParentCourseGradeForStudent(Data.Entities.Student student, Guid? parentCourseId, List<GradeModel> parentCourseGradesModelList)
        {
            foreach (var pcg in student.ParentCourseGrades.Where(p => p.ParentCourseId == parentCourseId))
            {
                pcg.GradeEarned = FindGradeOfStudentInParentGradesModelList(parentCourseGradesModelList,
                    student);
            }
        }

        private void CreateNewParentCourseGradeForStudent(List<GradeModel> parentCourseGradesModelList, Data.Entities.Student student,
    Guid? parentCourseId, Data.Entities.Session session)
        {
            var newParentCourseGrade = new ParentCourseGrade
            {
                GradeEarned = FindGradeOfStudentInParentGradesModelList(parentCourseGradesModelList, student),
                ParentCourseId = (Guid)parentCourseId,
                SchoolYear = session.SchoolYear,
                TermTypeId = session.TermTypeId,
                SchoolId = session.SchoolId
            };
            student.ParentCourseGrades.Add(newParentCourseGrade);
        }

        private string FindGradeOfStudentInParentGradesModelList(List<GradeModel> parentCourseGradesModelList, Data.Entities.Student student)
        {
            var grade =
                parentCourseGradesModelList.First(gradeModel => gradeModel.StudentUSI == student.StudentUSI).Grade;
            return grade == "Not Yet Graded" ? null : grade;
        }
    }
}