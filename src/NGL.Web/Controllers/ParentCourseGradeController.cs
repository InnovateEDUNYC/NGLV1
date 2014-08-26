using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private readonly ISectionRepository _sectionRepository;
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly GradesAndSectionToParentCourseGradesModelMapper _gradesAndSectionToParentCourseGradesModelMapper;
        private readonly IMapper<Section, ParentCourseGrade> _sectionToParentCourseGradeMapper;
        private readonly IGenericRepository _genericRepository;

        public ParentCourseGradeController(ISectionRepository sectionRepository, IParentCourseRepository parentCourseRepository, IMapper<Section, ParentCourseGrade> sectionToParentCourseGradeMapper, IGenericRepository genericRepository, IMapper<ParentCourseGrade, FindParentCourseModel> parentCourseGradeToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper)
        {
            _sectionRepository = sectionRepository;
            _parentCourseRepository = parentCourseRepository;
            _gradesAndSectionToParentCourseGradesModelMapper = new GradesAndSectionToParentCourseGradesModelMapper(parentCourseGradeToFindParentCourseModelMapper, parentCourseGradeToGradeModelMapper, studentToGradeModelMapper);
            _sectionToParentCourseGradeMapper = sectionToParentCourseGradeMapper;
            _genericRepository = genericRepository;
        }
        public virtual ActionResult Index()
        {
            
                return View(new ParentCourseGradesModel());
        }

        public virtual ActionResult Get(int? sessionId = null, Guid? parentCourseId = null)
        {
            if (sessionId == null || parentCourseId == null)
                return View(new ParentCourseGradesModel());

            var studentsWithParentCourseGrades = _parentCourseRepository.GetStudents((int) sessionId, (Guid) parentCourseId);

//            var section = _sectionRepository.GetWithStudentsAndSession(id.Value);
//            var grades = _parentCourseRepository.GetParentCourseGrades(section.LocalCourseCode);

            var parentCourseGradesModel = _gradesAndSectionToParentCourseGradesModelMapper.Build(studentsWithParentCourseGrades);

            return View("Index", parentCourseGradesModel);
        }


        public virtual ActionResult Edit(int? sessionId = null, Guid? parentCourseId = null)
        {
            if (sessionId == null || parentCourseId == null)
                return View(new ParentCourseGradesModel());

            var studentsWithParentCourseGrades = _parentCourseRepository.GetStudents((int)sessionId, (Guid)parentCourseId);
//            var section = _sectionRepository.GetWithStudentsAndSession(id.Value);
//            var grades = _parentCourseRepository.GetParentCourseGrades(section.LocalCourseCode);

            var parentCourseGradesModel = _gradesAndSectionToParentCourseGradesModelMapper.Build(studentsWithParentCourseGrades);

            return View(parentCourseGradesModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(ParentCourseGradesModel parentCourseGradesModel)
        {
//            if (parentCourseGradesModel.FindParentCourseModel.ParentCourseId != null)
//            {
//                var section =
//                    _sectionRepository.GetWithStudentsAndSession(
//                        parentCourseGradesModel.FindParentCourseModel.ParentCourseId.Value);
//                var parentCourse =
//                    _parentCourseRepository.GetParentCourse(section.LocalCourseCode);
//                var previouslyGradedStudents =
//                    _parentCourseRepository.GetParentCourseGrades(section.LocalCourseCode).Select(g => g.Student);
//
//                foreach (var newStudentParentCourseGrade in parentCourseGradesModel.ParentGradesModelList)
//                {
//                    CreateOrUpdateParentCourseGrade(previouslyGradedStudents, newStudentParentCourseGrade, section,
//                        parentCourse);
//                }
//                return RedirectToAction(MVC.ParentCourseGrade.Get(section.SectionIdentity));
//            }
            return View(parentCourseGradesModel);
        }


        private void CreateOrUpdateParentCourseGrade(IEnumerable<Student> previouslyGradedStudents,
            GradeModel newStudentParentCourseGrade, Section section, ParentCourse parentCourse)
        {
            ParentCourseGrade parentCourseGradeToBeSaved;
            if (studentWasPreviouslyGraded(previouslyGradedStudents, newStudentParentCourseGrade))
            {
                parentCourseGradeToBeSaved = _sectionToParentCourseGradeMapper.Build(section,
                    pcg =>
                    {
                        pcg.StudentUSI = newStudentParentCourseGrade.StudentUSI;
                        pcg.ParentCourseId = parentCourse.Id;
                        pcg.GradeEarned = newStudentParentCourseGrade.Grade;
                    });
                _genericRepository.Add(parentCourseGradeToBeSaved);
            }
            else
            {
                parentCourseGradeToBeSaved =
                    _parentCourseRepository.GetParentCourseGrade(newStudentParentCourseGrade.StudentUSI, parentCourse.Id);
                parentCourseGradeToBeSaved.GradeEarned = newStudentParentCourseGrade.Grade;
            }

            _genericRepository.Save();
        }

        private bool studentWasPreviouslyGraded(IEnumerable<Student> previouslyGradedStudents, GradeModel gradeModel)
        {
            return previouslyGradedStudents.Where(s => s.StudentUSI == gradeModel.StudentUSI).IsNullOrEmpty();
        }
    }
}