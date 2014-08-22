using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Configuration.Internal;
using System.Web.Mvc;
using Castle.Core.Internal;
using Humanizer;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;
using Microsoft.WindowsAzure.Storage.Table;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using NGL.Web.Models.ParentCourse;
using CreateModel = NGL.Web.Models.ParentCourse.CreateModel;
using IndexModel = NGL.Web.Models.ParentCourse.IndexModel;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        private readonly IMapper<CreateModel, ParentCourse> _createModelToParentCourseMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper<ParentCourse, IndexModel> _parentCourseToIndexModelMapper;
        private readonly IParentCourseRepository _parentCourseRepository;
        private readonly IMapper<Section, ParentCourseGrade> _sectionToParentCourseGradeMapper;
        private readonly GradesAndSectionToParentCourseGradesModelMapper _gradesAndSectionToParentCourseGradesModelMapper;
        private readonly ISectionRepository _sectionRepository;

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<Section, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper, IMapper<Section, ParentCourseGrade> sectionToParentCourseGradeMapper, ISectionRepository sectionRepository)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToParentCourseGradeMapper = sectionToParentCourseGradeMapper;
            _sectionRepository = sectionRepository;
            _gradesAndSectionToParentCourseGradesModelMapper = new GradesAndSectionToParentCourseGradesModelMapper(sectionToFindParentCourseModelMapper, parentCourseGradeToGradeModelMapper, studentToGradeModelMapper);
        }
        //
        // GET: /ParentCourse/
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            var parentCourses = _parentCourseRepository.GetParentCourses();

            var indexModels = parentCourses.Select(pc => _parentCourseToIndexModelMapper.Build(pc));

            return View(indexModels);
        }

        //
        // GET: /ParentCourse/Create
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ParentCourse/Create
        [HttpPost]
        [AuthorizeFor(Resource = "courseGeneration", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var parentCourse = _createModelToParentCourseMapper.Build(createModel);
            _genericRepository.Add(parentCourse);
            _genericRepository.Save();

            return RedirectToAction(Actions.Index());
        }

        // GET: /ParentCourse/Grades/1/edit
        public virtual ActionResult EditGrades(int? id = null)
        {
            if (id == null)
                return View(new ParentCourseGradesModel());
            var section = _sectionRepository.GetWithStudentsAndSession(id.Value);
            var grades = _parentCourseRepository.GetParentCourseGrades(section.LocalCourseCode);

            var parentCourseGradesModel = _gradesAndSectionToParentCourseGradesModelMapper.Build(grades, section);

            return View(parentCourseGradesModel);
        }

        // POST: /ParentCourse/Grades/1/edit
        [HttpPost]
        public virtual ActionResult EditGrades(ParentCourseGradesModel parentCourseGradesModel)
        {
            if (parentCourseGradesModel.FindParentCourseModel.SectionId != null)
            {
                var section =
                    _sectionRepository.GetWithStudentsAndSession(
                        parentCourseGradesModel.FindParentCourseModel.SectionId.Value);
                var parentCourse =
                    _parentCourseRepository.GetParentCourse(section.LocalCourseCode);
                var previouslyGradedStudents = _parentCourseRepository.GetParentCourseGrades(section.LocalCourseCode).Select(g => g.Student);

                foreach (var newStudentParentCourseGrade in parentCourseGradesModel.ParentGradesModelList)
                {
                    CreateOrUpdateParentCourseGrade(previouslyGradedStudents, newStudentParentCourseGrade, section,
                        parentCourse);
                }
            }
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
