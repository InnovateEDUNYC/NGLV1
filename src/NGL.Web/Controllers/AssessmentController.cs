using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Data.Queries;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;

namespace NGL.Web.Controllers
{
    public partial class AssessmentController : Controller
    {
        private readonly IMapper<CreateModel, Assessment> _createModelToAssessmentMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly StudentAssessmentsToAssessmentResultModelMapper _studentAssessmentsToAssessmentResultModelMapper;

        public AssessmentController(
            IMapper<CreateModel, Assessment> createModelToAssessmentMapper,
            IGenericRepository genericRepository,
            IAssessmentRepository assessmentRepository,
            StudentAssessmentsToAssessmentResultModelMapper studentAssessmentsToAssessmentResultModelMapper)
        {
            _createModelToAssessmentMapper = createModelToAssessmentMapper;
            _genericRepository = genericRepository;
            _assessmentRepository = assessmentRepository;
            _studentAssessmentsToAssessmentResultModelMapper = studentAssessmentsToAssessmentResultModelMapper;
        }

        //
        // GET: /Assessment/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Assessment/Create
        [HttpPost]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var assessment = _createModelToAssessmentMapper.Build(createModel);
            _genericRepository.Add(assessment);
            _genericRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }

        public virtual ActionResult EnterResults(int assessmentId)
        {
            var assessment = _genericRepository.Get<Assessment>(
                a => a.AssessmentIdentity == assessmentId,
                a => a.AssessmentSections.Select(asa => asa.Section.StudentSectionAssociations.Select(s => s.Student)));

            var studentSectionAssociations = assessment.AssessmentSections.First().Section.StudentSectionAssociations;
            var students = studentSectionAssociations.Select(s => s.Student);
            return View();
        }


        public virtual ActionResult Result(int studentUsi, int? sessionId, int week = 1)
		{
            var assessmentResultModel = new AssessmentResultModel { StudentUsi = studentUsi};

            if (sessionId == null)
            {
                return View(assessmentResultModel);
            }

            // todo - handle months
            var session = _genericRepository.Get<Session>(s => s.SessionIdentity == sessionId);
            var startDate = session.BeginDate.AddDays((week - 1) * 7);
            var endDate = startDate.AddDays(7);

            var studentAssessments = _assessmentRepository.GetAssessmentResults(assessmentResultModel.StudentUsi, startDate, endDate);
            assessmentResultModel = _studentAssessmentsToAssessmentResultModelMapper.Map(studentAssessments, startDate, endDate);
            assessmentResultModel.StudentUsi = studentUsi;
            assessmentResultModel.SessionId = sessionId;
            assessmentResultModel.Week = week;

            return View(assessmentResultModel);
		}
	}
}
