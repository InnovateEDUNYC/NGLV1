using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.ParentCourse
{
    public class ParentCourseGradeModelToParentCourseGradeMapper
    {
        private readonly ISessionRepository _sesssionRepository;

        public ParentCourseGradeModelToParentCourseGradeMapper(ISessionRepository sesssionRepository)
        {
            _sesssionRepository = sesssionRepository;
        }

        public void Map(ParentCourseGradesModel source, int studentUsi, ParentCourseGrade target)
        {

                target.GradeEarned = FindGradeOfStudentInParentGradesModelList(source.ParentGradesModelList, studentUsi);
        }

        public ParentCourseGrade Build(ParentCourseGradesModel parentCourseGradesModel, int studentUsi)
        {
            var session = _sesssionRepository.GetById((int)parentCourseGradesModel.FindParentCourseModel.SessionId);

            var parentCourseGrade = new ParentCourseGrade
            {
                ParentCourseId = (Guid)parentCourseGradesModel.FindParentCourseModel.ParentCourseId,
                SchoolYear = session.SchoolYear,
                TermTypeId = session.TermTypeId,
                SchoolId = session.SchoolId
            };

            Map(parentCourseGradesModel, studentUsi, parentCourseGrade);
            return parentCourseGrade;
        }

        private string FindGradeOfStudentInParentGradesModelList(IEnumerable<GradeModel> parentCourseGradesModelList, int studentUsi)
        {
            var grade =
                parentCourseGradesModelList.First(gradeModel => gradeModel.StudentUSI == studentUsi).Grade;
            return grade == "Not Yet Graded" ? null : grade;
        }
    }
}