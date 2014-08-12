using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;
using NGL.Web.Models.Section;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class ScheduleController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly IAssessmentSectionRepository _assessmentSectionRepository;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;
        private readonly IMapper<Session, SessionListItemModel> _sessionToSessionListItemModelMapper;
        private readonly IMapper<Section, AutocompleteModel> _sectionToAutocompleteModelMapper;
        private readonly IMapper<StudentSectionAssociation, SectionListItemModel> _studentSectionAssociationToSectionListItemModelMapper;
        private readonly IMapper<SetModel, StudentSectionAssociation> _setModelToStudentSectionAssociationMapper;
        private readonly IStudentSectionAttendanceRepository _studentSectionAttendanceRepositoryRepository;

        public ScheduleController(IGenericRepository genericRepository,
            IStudentSectionRepository studentSectionRepository,
            IAssessmentSectionRepository assessmentSectionRepository,
            ProfilePhotoUrlFetcher profilePhotoUrlFetcher, 
            IMapper<Session, SessionListItemModel> sessionToSessionListItemModelMapper,
            IMapper<Section, AutocompleteModel> sectionToAutocompleteModelMapper,
            IMapper<StudentSectionAssociation, SectionListItemModel> studentSectionAssociationToSectionListItemModelMapper, 
            IMapper<SetModel, StudentSectionAssociation> setModelToStudentSectionAssociationMapper, 
            IStudentSectionAttendanceRepository studentSectionAttendanceRepositoryRepository)
        {
            _genericRepository = genericRepository;
            _studentSectionRepository = studentSectionRepository;
            _assessmentSectionRepository = assessmentSectionRepository;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
            _sessionToSessionListItemModelMapper = sessionToSessionListItemModelMapper;
            _sectionToAutocompleteModelMapper = sectionToAutocompleteModelMapper;
            _studentSectionAssociationToSectionListItemModelMapper = studentSectionAssociationToSectionListItemModelMapper;
            _setModelToStudentSectionAssociationMapper = setModelToStudentSectionAssociationMapper;
            _studentSectionAttendanceRepositoryRepository = studentSectionAttendanceRepositoryRepository;
        }

        // GET: /Get/5
        [AuthorizeFor(Resource = "scheduleStudents", Operation = "create")]
        public virtual ActionResult Set(int id)
        {
            var student = _genericRepository.Get<Student>(s => s.StudentUSI == id);
            var profilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(student);
            var sessionModels = GetAllSessionModels();
            var currentlyEnrolledSections = GetCurrentlyEnrolledSectionsFor(id);

            var defaultSessionListModel = _sessionToSessionListItemModelMapper.Build(new SessionFilter(_genericRepository).FindSession(DateTime.Now));
            var setModel = SetModel.CreateNewWith(student, profilePhotoUrl, sessionModels, defaultSessionListModel, currentlyEnrolledSections);
            return View(setModel);
        }

        [HttpPost]
        public virtual JsonResult RemoveStudent(int studentSectionId)
        {
            var studentSectionAssociation = _studentSectionRepository.GetByIdentity(studentSectionId);
            var relatedAssessmentSections = _assessmentSectionRepository.GetByStudentSectionAssociation(studentSectionAssociation);
            var relatedStudentSectionAttendance = _studentSectionAttendanceRepositoryRepository.GetByStudentSectionAssociation(studentSectionAssociation);

            if (relatedAssessmentSections.IsNullOrEmpty() && relatedStudentSectionAttendance.IsNullOrEmpty())
            {
                _studentSectionRepository.Delete(studentSectionAssociation);
                return Json(new { DeletedCompletely = true}, JsonRequestBehavior.AllowGet);
            }
                
            var endDate = EarliestOf(studentSectionAssociation.EndDate.Value,  DateTime.Now.Date);
            studentSectionAssociation.EndDate = endDate;
            _genericRepository.Save();

            return Json(new {DeletedCompletely = false, EndDate = endDate.ToShortDateString()}, JsonRequestBehavior.AllowGet);
        }

        private DateTime EarliestOf(DateTime first, DateTime second)
        {
            return new DateTime(Math.Min(first.Ticks, second.Ticks));
        }

        // AJAX POST: /ScheduleStudent/
        [HttpPost]
        [AuthorizeFor(Resource = "scheduleStudents", Operation = "create")]
        public virtual JsonResult ScheduleStudent(SetModel setModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return Json(new {errors=errors}, JsonRequestBehavior.AllowGet);
            }
            var studentSectionAssociation = _setModelToStudentSectionAssociationMapper.Build(setModel);

            _genericRepository.Add(studentSectionAssociation);
            _genericRepository.Save();

            var sectionListItem = _studentSectionAssociationToSectionListItemModelMapper.Build(studentSectionAssociation);

            return Json(sectionListItem, JsonRequestBehavior.AllowGet);
        }

        // AJAX POST: /GetSections/SCI4
        [HttpPost]
        [AuthorizeFor(Resource = "scheduleStudents", Operation = "create")]
        public virtual JsonResult GetSections(string searchString, int sessionId)
        {
            var autoCompleteModels = GetAllSectionAutocompleteModelsWith(searchString, sessionId);
            return Json(autoCompleteModels, JsonRequestBehavior.AllowGet);
        }

        private List<SectionListItemModel> GetCurrentlyEnrolledSectionsFor(int studentUSI)
        {
            var currentlyEnrolledStudentSectionAssociationEntities = _genericRepository.GetAll<StudentSectionAssociation>()
                .Where(ssa => ssa.StudentUSI == studentUSI);
            var currentlyEnrolledSections = new List<SectionListItemModel>();

            foreach (StudentSectionAssociation ssa in currentlyEnrolledStudentSectionAssociationEntities)
            {
                currentlyEnrolledSections.Add(_studentSectionAssociationToSectionListItemModelMapper.Build(ssa));
            }

            return currentlyEnrolledSections;
        }

        private IEnumerable<AutocompleteModel> GetAllSectionAutocompleteModelsWith(string searchString, int sessionId)
        {
            var session = _genericRepository.Get<Session>(s => s.SessionIdentity == sessionId);
            var query = new SectionsBySectionNameAndSessionQuery(searchString, session);
            var sections = _genericRepository.GetAll(query);
            var autocompleteModels = sections.Select(section => _sectionToAutocompleteModelMapper.Build(section)).ToList();

            if (autocompleteModels.IsNullOrEmpty())
            {
                autocompleteModels.Add(new AutocompleteModel{LabelName = "No results"});
            }

            return autocompleteModels;
        }

        private List<SessionListItemModel> GetAllSessionModels()
        {
            var sessions = _genericRepository.GetAll<Session>();
            return sessions.Select(session => _sessionToSessionListItemModelMapper.Build(session)).ToList();
        }
	}
}