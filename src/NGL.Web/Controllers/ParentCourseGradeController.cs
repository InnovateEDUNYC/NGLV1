using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Grade;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseGradeController : Controller
    {
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly StudentsSesssionParentCourseToParentCourseGradesModelMapper _studentsSesssionParentCourseToParentCourseGradesModelMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly ISessionRepository _sesssionRepository;
        private readonly ParentCourseGradesModelToStudentsMapper _parentCourseGradesModelToStudentsMapper;
        private readonly ParentCourseGradeToCsvMapper _parentCourseToCsvMapper;

        public ParentCourseGradeController(IParentCourseRepository parentCourseRepository, IGenericRepository genericRepository, ISessionRepository sesssionRepository, ParentCourseGradesModelToStudentsMapper parentCourseGradesModelToStudentsMapper, StudentsSesssionParentCourseToParentCourseGradesModelMapper studentsSesssionParentCourseToParentCourseGradesModelMapper, ParentCourseGradeToCsvMapper parentCourseToCsvMapper)
        {
            _parentCourseRepository = parentCourseRepository;
            _genericRepository = genericRepository;
            _sesssionRepository = sesssionRepository;
            _parentCourseGradesModelToStudentsMapper = parentCourseGradesModelToStudentsMapper;
            _studentsSesssionParentCourseToParentCourseGradesModelMapper = studentsSesssionParentCourseToParentCourseGradesModelMapper;
            _parentCourseToCsvMapper = parentCourseToCsvMapper;
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
            var students = _parentCourseRepository.GetStudents((int) sessionId, (Guid) parentCourseId);
            _parentCourseRepository.GetParentCourseGrades((Guid) parentCourseId, (int) sessionId);
            var parentCourseGradesModel = _studentsSesssionParentCourseToParentCourseGradesModelMapper.Build(students, session, parentCourse);

            return View("Index", parentCourseGradesModel);
        }


        public virtual ActionResult Edit(int? sessionId = null, Guid? parentCourseId = null)
        {
            if (sessionId == null || parentCourseId == null)
                return View(new ParentCourseGradesModel());

            var students = _parentCourseRepository.GetStudents((int)sessionId, (Guid)parentCourseId);
            _parentCourseRepository.GetParentCourseGrades((Guid)parentCourseId, (int)sessionId);
            var session = _sesssionRepository.GetById((int)sessionId);
            var parentCourse = _parentCourseRepository.GetById((Guid) parentCourseId);
            var parentCourseGradesModel = _studentsSesssionParentCourseToParentCourseGradesModelMapper.Build(students, session, parentCourse);

            return View(parentCourseGradesModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(ParentCourseGradesModel parentCourseGradesModel)
        {
            if (!ModelState.IsValid)
            {
                return View(parentCourseGradesModel);
            }
            if (parentCourseGradesModel.FindParentCourseModel.ParentCourseId == null ||
                parentCourseGradesModel.FindParentCourseModel.SessionId == null) 
                return View(parentCourseGradesModel);

            var students = _parentCourseRepository.GetStudents((int)parentCourseGradesModel.FindParentCourseModel.SessionId, (Guid)parentCourseGradesModel.FindParentCourseModel.ParentCourseId);

            _parentCourseRepository.GetParentCourseGrades((Guid) parentCourseGradesModel.FindParentCourseModel.ParentCourseId, (int) parentCourseGradesModel.FindParentCourseModel.SessionId);

            var studentsToBeGraded =  students.Where(
                s =>
                    parentCourseGradesModel.ParentGradesModelList.Any(
                        gradeModel => gradeModel.StudentUSI == s.StudentUSI)).ToList();

            _parentCourseGradesModelToStudentsMapper.Map(parentCourseGradesModel, studentsToBeGraded);

            _genericRepository.Save();

            return RedirectToAction(MVC.ParentCourseGrade.Get(parentCourseGradesModel.FindParentCourseModel.SessionId, parentCourseGradesModel.FindParentCourseModel.ParentCourseId));
        }

        public virtual ActionResult ExportCsv(int? sessionId, Guid? parentCourseId)
        {
            if (!sessionId.HasValue || !parentCourseId.HasValue)
                return RedirectToAction(MVC.ParentCourseGrade.Get());

            var parentCourseGrades = _parentCourseRepository.GetParentCourseGrades(parentCourseId.Value, sessionId.Value);

            if (parentCourseGrades.IsNullOrEmpty())
                return RedirectToAction(MVC.ParentCourseGrade.Get());

            var bytesInStream = _parentCourseToCsvMapper.Build(parentCourseGrades);
            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=CourseGrades.csv");
            Response.BinaryWrite(bytesInStream);
            Response.End();

            return new FileContentResult(bytesInStream, "application/force-download");
        }

    }
}