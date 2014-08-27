using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseGradeController : Controller
    {
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly StudentsSesssionParentCourseToParentCourseGradesModelMapper _studentsSesssionParentCourseToParentCourseGradesModelMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly ISessionRepository _sesssionRepository;

        public ParentCourseGradeController(IParentCourseRepository parentCourseRepository, IGenericRepository genericRepository, IMapper<Session, FindParentCourseModel> sessionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper, ISessionRepository sesssionRepository)
        {
            _parentCourseRepository = parentCourseRepository;
            _studentsSesssionParentCourseToParentCourseGradesModelMapper = new StudentsSesssionParentCourseToParentCourseGradesModelMapper(sessionToFindParentCourseModelMapper, parentCourseGradeToGradeModelMapper, studentToGradeModelMapper);
            _genericRepository = genericRepository;
            _sesssionRepository = sesssionRepository;
        }
        public virtual ActionResult Index()
        {
            
                return View(new ParentCourseGradesModel());
        }

        public virtual ActionResult Get(int? sessionId = null, Guid? parentCourseId = null)
        {
            if (sessionId == null || parentCourseId == null)
                return View(new ParentCourseGradesModel());

            var session = _sesssionRepository.GetById((int) sessionId);
            var parentCourse = _parentCourseRepository.GetById((Guid) parentCourseId);

            var studentsWithParentCourseGrades = _parentCourseRepository.GetStudents((int) sessionId, (Guid) parentCourseId);

            var parentCourseGradesModel = _studentsSesssionParentCourseToParentCourseGradesModelMapper.Build(studentsWithParentCourseGrades, session, parentCourse);

            return View("Index", parentCourseGradesModel);
        }


        public virtual ActionResult Edit(int? sessionId = null, Guid? parentCourseId = null)
        {
            if (sessionId == null || parentCourseId == null)
                return View(new ParentCourseGradesModel());

            var studentsWithParentCourseGrades = _parentCourseRepository.GetStudents((int)sessionId, (Guid)parentCourseId);
            var session = _sesssionRepository.GetById((int)sessionId);
            var parentCourse = _parentCourseRepository.GetById((Guid) parentCourseId);
            var parentCourseGradesModel = _studentsSesssionParentCourseToParentCourseGradesModelMapper.Build(studentsWithParentCourseGrades, session, parentCourse);

            return View(parentCourseGradesModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(ParentCourseGradesModel parentCourseGradesModel)
        {
            if (parentCourseGradesModel.FindParentCourseModel.ParentCourseId == null ||
                parentCourseGradesModel.FindParentCourseModel.SessionId == null) 
                return View(parentCourseGradesModel);

            var sessionId = parentCourseGradesModel.FindParentCourseModel.SessionId;
            var session = _sesssionRepository.GetById((int) sessionId);
            var parentCourseId = parentCourseGradesModel.FindParentCourseModel.ParentCourseId;
            var parentCourseGradesModelList = parentCourseGradesModel.ParentGradesModelList;

            var studentsWithParentCourseGrades = _parentCourseRepository.GetStudents((int)sessionId, (Guid)parentCourseId);

            var studentsToBeGraded =  studentsWithParentCourseGrades.Where(
                s =>
                    parentCourseGradesModel.ParentGradesModelList.Any(
                        gradeModel => gradeModel.StudentUSI == s.StudentUSI)).ToList();
                

            foreach (var student in studentsToBeGraded)
            {
                if (!student.ParentCourseGrades.IsNullOrEmpty() || student.ParentCourseGrades.Any(pcg => pcg.ParentCourseId == parentCourseId)){
                            
                    foreach(var pcg in student.ParentCourseGrades.Where(p => p.ParentCourseId == parentCourseId)){
                        pcg.GradeEarned = _findGradeOfStudentInParentGradesModelList(parentCourseGradesModelList,
                            student);
                    }
                }
                else
                {
                    var newParentCourseGrade = new ParentCourseGrade
                    {
                        GradeEarned = _findGradeOfStudentInParentGradesModelList(parentCourseGradesModelList, student),
                        ParentCourseId = (Guid) parentCourseId,
                        SchoolYear = session.SchoolYear,
                        TermTypeId = session.TermTypeId,
                        SchoolId = session.SchoolId
                    };
                    student.ParentCourseGrades.Add(newParentCourseGrade);
                }
            }

            _genericRepository.Save();

            return RedirectToAction(MVC.ParentCourseGrade.Get(sessionId, parentCourseId));
        }

        private string _findGradeOfStudentInParentGradesModelList(List<GradeModel> parentCourseGradesModelList, Student student)
        {
            var grade =
                parentCourseGradesModelList.First(gradeModel => gradeModel.StudentUSI == student.StudentUSI).Grade;
            return grade == "Not Yet Graded" ? null : grade;
        }

    }
}