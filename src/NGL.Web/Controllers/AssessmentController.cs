using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Infrastructure.Security;
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
        private readonly IMapper<Assessment, EnterResultsModel> _assessmentToEnterResultsModelMapper;
        private readonly EnterResultsStudentModelToStudentAssessmentMapper
            _enterResultsStudentModelToStudentAssessmentMapper;
        private readonly IMapper<Assessment, IndexModel> _assessmentToAssessmentIndexModelMapper;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;
        private readonly ILearningStandardRepository _learningStandardRepository;
        private readonly ISessionFilter _sessionFilter;

        public AssessmentController(IMapper<CreateModel, Assessment> createModelToAssessmentMapper,
            IGenericRepository genericRepository,
            IAssessmentRepository assessmentRepository,
            StudentAssessmentsToAssessmentResultModelMapper studentAssessmentsToAssessmentResultModelMapper,
            IMapper<Assessment, EnterResultsModel> assessmentToEnterResultsModelMapper,
            EnterResultsStudentModelToStudentAssessmentMapper enterResultsStudentModelToStudentAssessmentMapper,
			IMapper<Assessment, IndexModel> assessmentToAssessmentIndexModelMapper,
            ProfilePhotoUrlFetcher profilePhotoUrlFetcher, ILearningStandardRepository learningStandardRepository, ISessionFilter sessionFilter)
        {
            _createModelToAssessmentMapper = createModelToAssessmentMapper;
            _genericRepository = genericRepository;
            _assessmentRepository = assessmentRepository;
            _studentAssessmentsToAssessmentResultModelMapper = studentAssessmentsToAssessmentResultModelMapper;
            _assessmentToEnterResultsModelMapper = assessmentToEnterResultsModelMapper;
            _enterResultsStudentModelToStudentAssessmentMapper = enterResultsStudentModelToStudentAssessmentMapper;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
             _learningStandardRepository = learningStandardRepository;
            _sessionFilter = sessionFilter;
            _assessmentToAssessmentIndexModelMapper = assessmentToAssessmentIndexModelMapper;
        }

        //
        // GET: /Assessment/
        public virtual ActionResult Index()
        {
            var assessments = _assessmentRepository.GetAssessments();

            var assessmentIndexModels = assessments.Select(a => _assessmentToAssessmentIndexModelMapper.Build(a));

            return View(assessmentIndexModels);
        }

        //
        // GET: /Assessment/Create
        [AuthorizeFor(Resource = "assessment", Operation = "create")]
        public virtual ActionResult Create()
        {
            var commonCoreStandards = _learningStandardRepository.GetAllCommonCoreAnchorStandards();
            var createModel = CreateModel.CreateNewWith(commonCoreStandards);
            return View(createModel);
        }

        //

        // POST: /Assessment/Create

        [HttpPost]
        [AuthorizeFor(Resource = "assessment", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                createModel.CommonCoreStandards = _learningStandardRepository.GetAllCommonCoreAnchorStandards();
                return View(createModel);
            }

            var assessment = _createModelToAssessmentMapper.Build(createModel);

            _assessmentRepository.Save(assessment);
            return RedirectToAction(MVC.Assessment.Index());
        }

        //
        // GET: /Assessment/EnterResults/1/
        public virtual ActionResult EnterResults(int id)
        {
            var assessment = _assessmentRepository.GetAssessmentByAssessmentId(id);
            
            if (assessment == null) return View("Error");

            var enterResultsModel = _assessmentToEnterResultsModelMapper.Build(assessment);

            return View(enterResultsModel);
        }

        //
        // POST: /Assessment/EnterResults/1/
        [HttpPost]
        public virtual ActionResult EnterResults(EnterResultsModel enterResultsModel)
        {
            var assessmentId = enterResultsModel.AssessmentId;
            var assessment = _assessmentRepository.GetAssessmentByAssessmentId(assessmentId);
            if (!ModelState.IsValid)
            {
                enterResultsModel = _assessmentToEnterResultsModelMapper.Build(assessment);
                return View(enterResultsModel);
            }
            var enterResultsStudentModels = enterResultsModel.StudentResults;
            

            var currentStudentAssessments = assessment.StudentAssessments;
            if (currentStudentAssessments.IsNullOrEmpty())
            {
                CreateStudentAssessmentScoreResults(assessment, enterResultsStudentModels);
            }
            else
            {
                var currentStudentAssessmentScoreResults = currentStudentAssessments.Select(sa => sa.StudentAssessmentScoreResults.First());
                UpdateStudentAssessmentScoreResults(currentStudentAssessmentScoreResults, enterResultsStudentModels);
            }

            _genericRepository.Save();

            return RedirectToAction(MVC.Assessment.Index());
        }

        private void UpdateStudentAssessmentScoreResults(IEnumerable<StudentAssessmentScoreResult> currentResultEntities, List<EnterResultsStudentModel> newResultModels)
        {
            foreach (var currentResultEntity in currentResultEntities.ToList())
            {
                var newResultModel =
                    newResultModels.First(
                        studentScoreResult => studentScoreResult.StudentUsi == currentResultEntity.StudentUSI);
                currentResultEntity.Result = newResultModel.AssessmentResult.HasValue ? newResultModel.AssessmentResult.Value.ToString() : "";
            }
        }

        private void CreateStudentAssessmentScoreResults(Assessment assessment, IEnumerable<EnterResultsStudentModel> enterResultsStudentModels)
        {
            foreach (EnterResultsStudentModel enterResultsStudentModel in enterResultsStudentModels.ToList())
            {
                var studentAssessment = _enterResultsStudentModelToStudentAssessmentMapper.Build(enterResultsStudentModel, assessment);

                _assessmentRepository.SaveStudentAssessment(studentAssessment);
            }
        }

        [AuthorizeFor(Resource = "assessment", Operation = "view")]
        public virtual ActionResult Week(int studentUsi, int? sessionId, int dayFrom = 1, int dayTo = 7)
        {
            if (sessionId == null)
            {
                var currentSession = _sessionFilter.FindSession(DateTime.Now);
                if (currentSession != null)
                    sessionId = currentSession.SessionIdentity;
            }

            var assessmentResultModel = Result(studentUsi, sessionId, dayFrom, dayTo);
            return View(assessmentResultModel);
        }

        [AuthorizeFor(Resource = "assessment", Operation = "view")]
        public virtual ActionResult Month(int studentUsi, int? sessionId, int dayFrom = 1, int dayTo = 30)
        {
            var assessmentResultModel = Result(studentUsi, sessionId, dayFrom, dayTo);
            return View(assessmentResultModel);
        }

        private AssessmentResultModel Result(int studentUsi, int? sessionId, int dayFrom = 1, int dayTo = 7)
        {

            var assessmentResultModel = new AssessmentResultModel();
            if (sessionId != null)
            {
                var session = _genericRepository.Get<Session>(s => s.SessionIdentity == sessionId);
                var startDate = session.BeginDate.AddDays(dayFrom - 1);
                var endDate = session.BeginDate.AddDays(dayTo - 1);

                var studentAssessments = _assessmentRepository.GetAssessmentResults(studentUsi, startDate, endDate);
                assessmentResultModel = _studentAssessmentsToAssessmentResultModelMapper.Map(studentAssessments, startDate, endDate);
                assessmentResultModel.Session = session.SessionName;
            }

            var student = _genericRepository.Get<Student>(s => s.StudentUSI == studentUsi);
            var profilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(student);

            assessmentResultModel.Update(student, profilePhotoUrl, sessionId, dayFrom, dayTo);

            return assessmentResultModel;
        }

    }
}
