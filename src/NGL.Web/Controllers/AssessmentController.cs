using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Expressions;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Assessment;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class AssessmentController : Controller
    {
        private readonly IMapper<CreateModel, Assessment> _createModelToAssessmentMapper;
        private readonly IGenericRepository _genericRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly StudentAssessmentsToAssessmentResultModelMapper _studentAssessmentsToAssessmentResultModelMapper;
        private readonly IMapper<Assessment, EnterResultsModel> _assessmentToEnterResultsModelMapper;
        private readonly IMapper<EnterResultsStudentModel, StudentAssessmentScoreResult>
            _enterResultsStudentModelToStudentAssessmentScoreResultMapper;
        private readonly IMapper<EnterResultsStudentModel, StudentAssessment>
            _enterResultsStudentModelToStudentAssessmentMapper;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;

        private readonly IMapper<CreateModel, AssessmentPerformanceLevel> _createModelToAssessmentPerformanceLevelMapper;

        public AssessmentController(IMapper<CreateModel, Assessment> createModelToAssessmentMapper,
            IGenericRepository genericRepository,
            IAssessmentRepository assessmentRepository,
            StudentAssessmentsToAssessmentResultModelMapper studentAssessmentsToAssessmentResultModelMapper,
            IMapper<Assessment, EnterResultsModel> assessmentToEnterResultsModelMapper,
            IMapper<EnterResultsStudentModel, StudentAssessmentScoreResult>
                enterResultsStudentModelToStudentAssessmentScoreResultMapper,
            IMapper<EnterResultsStudentModel, StudentAssessment> enterResultsStudentModelToStudentAssessmentMapper, 
            IMapper<CreateModel, AssessmentPerformanceLevel> createModelToAssessmentPerformanceLevelMapper,
            ProfilePhotoUrlFetcher profilePhotoUrlFetcher)
        {
            _createModelToAssessmentMapper = createModelToAssessmentMapper;
            _genericRepository = genericRepository;
            _assessmentRepository = assessmentRepository;
            _studentAssessmentsToAssessmentResultModelMapper = studentAssessmentsToAssessmentResultModelMapper;
            _assessmentToEnterResultsModelMapper = assessmentToEnterResultsModelMapper;
            _enterResultsStudentModelToStudentAssessmentScoreResultMapper =
                enterResultsStudentModelToStudentAssessmentScoreResultMapper;
            _enterResultsStudentModelToStudentAssessmentMapper = enterResultsStudentModelToStudentAssessmentMapper;
            _createModelToAssessmentPerformanceLevelMapper = createModelToAssessmentPerformanceLevelMapper;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
        }

        //
        // GET: /Assessment/Create
        [AuthorizeFor(Resource = "assessment", Operation = "create")]
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Assessment/Create
        [HttpPost]
        [AuthorizeFor(Resource = "assessment", Operation = "create")]
        public virtual ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);

            var assessment = _createModelToAssessmentMapper.Build(createModel);
            var nearMastery = GetPerformanceLevel(createModel, assessment, PerformanceLevelDescriptorEnum.NearMastery);
            var mastery = GetPerformanceLevel(createModel, assessment, PerformanceLevelDescriptorEnum.Mastery); ;

            _genericRepository.Add(assessment);
            _genericRepository.Add(nearMastery);
            _genericRepository.Add(mastery);
            _genericRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }

        public virtual ActionResult EnterResults(int assessmentId)
        {
            var assessment = _genericRepository.Get<Assessment>(
                a => a.AssessmentIdentity == assessmentId,
                a => a.AssessmentSections.Select(asa => asa.Section.StudentSectionAssociations.Select(s => s.Student)),
                a => a.AssessmentSections.Select(asa => asa.Section.Session),
                a => a.StudentAssessments.Select(sa => sa.StudentAssessmentScoreResults));

            if (assessment == null) return View();

            var enterResultsModel = _assessmentToEnterResultsModelMapper.Build(assessment);

            return View(enterResultsModel);
        }

        [HttpPost]
        public virtual ActionResult EnterResults(EnterResultsModel enterResultsModel)
        {
            var enterResultsStudentModels = enterResultsModel.StudentResults;
            var assessmentId = enterResultsModel.AssessmentId;
            var assessment = _genericRepository.Get<Assessment>(
                a => a.AssessmentIdentity == assessmentId,
                a => a.StudentAssessments);
            var studentAssessments = assessment.StudentAssessments;
            var studentAssessmentScoreResults = new List<StudentAssessmentScoreResult>();
            foreach (var enterResultsStudentModel in enterResultsStudentModels)
            {
                AddToStudentAssements(studentAssessments, enterResultsStudentModel, assessment);
                AddToStudentAssessmentScoreResults(studentAssessmentScoreResults, enterResultsStudentModel, assessment);
            }

            foreach (var studentAssessmentScoreResult in studentAssessmentScoreResults)
                _genericRepository.Add(studentAssessmentScoreResult);
            foreach (var studentAssessment in studentAssessments)
                _genericRepository.Add(studentAssessment);
            _genericRepository.Save();

            return RedirectToAction(MVC.Home.Index());
        }

        private void AddToStudentAssessmentScoreResults(List<StudentAssessmentScoreResult> studentAssessmentScoreResults,
            EnterResultsStudentModel enterResultsStudentModel, Assessment assessment)
        {
            studentAssessmentScoreResults.Add(
                _enterResultsStudentModelToStudentAssessmentScoreResultMapper.Build(enterResultsStudentModel, asr =>
                {
                    asr.AssessmentTitle = assessment.AssessmentTitle;
                    asr.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                    asr.AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
                    asr.Version = assessment.Version;
                    asr.AdministrationDate = assessment.AdministeredDate;
                }));
        }

        private void AddToStudentAssements(ICollection<StudentAssessment> studentAssessments,
            EnterResultsStudentModel enterResultsStudentModel,
            Assessment assessment)
        {
            studentAssessments.Add(_enterResultsStudentModelToStudentAssessmentMapper.Build(
                enterResultsStudentModel,
                sa =>
                {
                    sa.AssessmentTitle = assessment.AssessmentTitle;
                    sa.AcademicSubjectDescriptorId = assessment.AcademicSubjectDescriptorId;
                    sa.AssessedGradeLevelDescriptorId = assessment.AssessedGradeLevelDescriptorId;
                    sa.Version = assessment.Version;
                    sa.AdministrationDate = assessment.AdministeredDate;
                }));
        }

	    [AuthorizeFor(Resource = "assessment", Operation = "view")]
        public virtual ActionResult Result(int studentUsi, int? sessionId, int dayFrom = 1, int dayTo = 7)
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

            var profilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(studentUsi);
            var student = _genericRepository.Get<Student>(s => s.StudentUSI == studentUsi);

	        assessmentResultModel.Update(student, profilePhotoUrl, sessionId, dayFrom, dayTo);

            return View(assessmentResultModel);
		}

        private AssessmentPerformanceLevel GetPerformanceLevel(CreateModel createModel, Assessment assessment, 
            PerformanceLevelDescriptorEnum performanceLevelDescriptor)
        {
            var expression = new PerformanceLevelMapperExpression(assessment, performanceLevelDescriptor);
            return _createModelToAssessmentPerformanceLevelMapper.Build(createModel, expression.Expression);
        }
    }
}
