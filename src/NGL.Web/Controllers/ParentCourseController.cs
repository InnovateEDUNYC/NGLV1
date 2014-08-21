using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using NGL.Web.Models.ParentCourse;

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

        public ParentCourseController(IGenericRepository genericRepository, IMapper<CreateModel, ParentCourse> createModelToParentCourseMapper, IMapper<ParentCourse, IndexModel> parentCourseToIndexModelMapper, IParentCourseRepository parentCourseRepository, IMapper<Section, FindParentCourseModel> sectionToFindParentCourseModelMapper, IMapper<ParentCourseGrade, GradeModel> parentCourseGradeToGradeModelMapper, IMapper<Student, GradeModel> studentToGradeModelMapper)
        {
            _genericRepository = genericRepository;
            _createModelToParentCourseMapper = createModelToParentCourseMapper;
            _parentCourseToIndexModelMapper = parentCourseToIndexModelMapper;
            _parentCourseRepository = parentCourseRepository;
            _sectionToFindParentCourseModelMapper = sectionToFindParentCourseModelMapper;
            _parentCourseGradeToGradeModelMapper = parentCourseGradeToGradeModelMapper;
            _studentToGradeModelMapper = studentToGradeModelMapper;
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

            var studentsInSection = section.StudentSectionAssociations.Select(ssa => ssa.Student).ToList();

            var grades = _genericRepository.Query<ParentCourseGrade>().Where(g => g.ParentCourse.Courses.Any(c => c.CourseCode == section.LocalCourseCode)).Include(g => g.Student).ToList();

            var studentsWithGrades = grades.Select(g => g.Student).ToList();

            var studentsInSectionWithoutGrades = studentsInSection.Except(studentsWithGrades).ToList();

            var findParentCourseModel = _sectionToFindParentCourseModelMapper.Build(section);

            var parentGradesModelEnumerable = grades.Select(grade => _parentCourseGradeToGradeModelMapper.Build(grade));

            parentGradesModelEnumerable = parentGradesModelEnumerable.Concat(studentsInSectionWithoutGrades.Select(s => _studentToGradeModelMapper.Build(s)));

            var parentCourseGradesModel = new ParentCourseGradesModel();

            parentCourseGradesModel.FindParentCourseModel = findParentCourseModel;
            parentCourseGradesModel.ParentGradesModelList = parentGradesModelEnumerable.ToList();

            return View(parentCourseGradesModel);
        }
    }
}
