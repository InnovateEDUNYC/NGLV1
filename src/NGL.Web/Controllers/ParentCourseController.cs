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
        private readonly IMapper<Section, FindParentCourseModel> _sectionToFindParentCourseModelMapper;
        private readonly IMapper<ParentCourseGrade, GradeModel> _parentCourseGradeToGradeModelMapper;
        private readonly IMapper<Student, GradeModel> _studentToGradeModelMapper;
        private readonly IMapper<Section, ParentCourseGrade> _sectionToParentCourseGradeMapper;

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<Section, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper, IMapper<Section, ParentCourseGrade> sectionToParentCourseGradeMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
            _parentCourseGradeToGradeModelMapper = parentCourseGradeToGradeModelMapper;
            _studentToGradeModelMapper = studentToGradeModelMapper;
            _sectionToParentCourseGradeMapper = sectionToParentCourseGradeMapper;
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
        public virtual ActionResult Grades(int? sectionId = null)
        {
            if (sectionId == null)
                return View(new ParentCourseGradesModel());

            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == sectionId, s => s.StudentSectionAssociations.Select(ssa => ssa.Student), s => s.Session);
            var grades = _genericRepository.Query<ParentCourseGrade>().Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == section.LocalCourseCode)).Include(g => g.Student).ToList();
            

            var gradesAndSectionToParentCourseGradesModelMapper = new GradesAndSectionToParentCourseGradesModelMapper(_sectionToFindParentCourseModelMapper, _parentCourseGradeToGradeModelMapper, _studentToGradeModelMapper);

            var parentCourseGradesModel = gradesAndSectionToParentCourseGradesModelMapper.Build(grades, section);

            return View(parentCourseGradesModel);
        }

        // POST: /ParentCourse/Grades?sectionId=1
        [HttpPost]
        public virtual ActionResult Grades(ParentCourseGradesModel parentCourseGradesModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == parentCourseGradesModel.FindParentCourseModel.SectionId, s => s.StudentSectionAssociations.Select(ssa => ssa.Student), s => s.Session);

            var parentCourse =
                _genericRepository.Get<ParentCourse>(pc => pc.Courses.Any(c => c.CourseCode == section.LocalCourseCode));

            var oldGrades = _genericRepository.Query<ParentCourseGrade>().Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == section.LocalCourseCode)).Include(g => g.Student).ToList();

            var previouslyGradedStudents = oldGrades.Select(g => g.Student);

            foreach (var gradeModel in parentCourseGradesModel.ParentGradesModelList)
            {
                ParentCourseGrade parentCourseGrade;
                if (previouslyGradedStudents.Where(s => s.StudentUSI == gradeModel.StudentUSI).IsNullOrEmpty())
                {
                    parentCourseGrade = _sectionToParentCourseGradeMapper.Build(section,
                        pcg =>
                        {
                            pcg.StudentUSI = gradeModel.StudentUSI;
                            pcg.ParentCourseId = parentCourse.Id;
                            pcg.GradeEarned = gradeModel.Grade;
                        });
                    _genericRepository.Add(parentCourseGrade);
                }
                else
                {
                    parentCourseGrade =
                        _genericRepository.Get<ParentCourseGrade>(
                            pcg => pcg.StudentUSI == gradeModel.StudentUSI && pcg.ParentCourseId == parentCourse.Id);
                    parentCourseGrade.GradeEarned = gradeModel.Grade;
                }

                _genericRepository.Save();
            }

            return View(parentCourseGradesModel);
        }
    }
}
