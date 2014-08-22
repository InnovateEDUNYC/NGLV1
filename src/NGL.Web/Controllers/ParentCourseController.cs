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

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<Section, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper, IMapper<Section, ParentCourseGrade> sectionToParentCourseGradeMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToParentCourseGradeMapper = sectionToParentCourseGradeMapper;
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

        // GET: /ParentCourse/Grades
        public virtual ActionResult Grades(int? id = null)
        {
            if (id == null)
                return View(new ParentCourseGradesModel());

            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == id, s => s.StudentSectionAssociations.Select(ssa => ssa.Student), s => s.Session);
            var grades = _genericRepository.Query<ParentCourseGrade>().Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == section.LocalCourseCode)).Include(g => g.Student).ToList();

            var parentCourseGradesModel = _gradesAndSectionToParentCourseGradesModelMapper.Build(grades, section);

            return View(parentCourseGradesModel);
        }

        // POST: /ParentCourse/Grades/1
        [HttpPost]
        public virtual ActionResult Grades(ParentCourseGradesModel parentCourseGradesModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == parentCourseGradesModel.FindParentCourseModel.SectionId, s => s.StudentSectionAssociations.Select(ssa => ssa.Student), s => s.Session);

            var parentCourse =
                _genericRepository.Get<ParentCourse>(pc => pc.Courses.Any(c => c.CourseCode == section.LocalCourseCode));

            var previouslyGradedStudents = _genericRepository.Query<ParentCourseGrade>().Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == section.LocalCourseCode)).Include(g => g.Student).ToList().Select(g => g.Student);

            foreach (var newStudentParentCourseGrade in parentCourseGradesModel.ParentGradesModelList)
            {
                CreateOrUpdateParentCourseGrade(previouslyGradedStudents, newStudentParentCourseGrade, section, parentCourse);
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
                    _genericRepository.Get<ParentCourseGrade>(
                        pcg => pcg.StudentUSI == newStudentParentCourseGrade.StudentUSI && pcg.ParentCourseId == parentCourse.Id);
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
