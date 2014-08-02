﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;
using NGL.Web.Models.Section;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class ScheduleController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;
        private readonly IMapper<Session, SessionListItemModel> _sessionToSessionListItemModelMapper;
        private readonly IMapper<Section, AutocompleteModel> _sectionToAutocompleteModelMapper;
        private readonly IMapper<StudentSectionAssociation, SectionListItemModel> _studentSectionAssociationToSectionListItemModelMapper;

        public ScheduleController(IGenericRepository genericRepository,
            ISchoolRepository schoolRepository,
            ProfilePhotoUrlFetcher profilePhotoUrlFetcher, 
            IMapper<Session, SessionListItemModel> sessionToSessionListItemModelMapper,
            IMapper<Section, AutocompleteModel> sectionToAutocompleteModelMapper,
            IMapper<StudentSectionAssociation, SectionListItemModel> studentSectionAssociationToSectionListItemModelMapper )
        {
            _genericRepository = genericRepository;
            _schoolRepository = schoolRepository;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
            _sessionToSessionListItemModelMapper = sessionToSessionListItemModelMapper;
            _sectionToAutocompleteModelMapper = sectionToAutocompleteModelMapper;
            _studentSectionAssociationToSectionListItemModelMapper = studentSectionAssociationToSectionListItemModelMapper;
        }

        //
        // GET: /Set/5
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

        //
        // AJAX POST: /ScheduleStudent/
        [HttpPost]
        public virtual JsonResult ScheduleStudent(SetModel setModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == setModel.SectionId);
            var schoolId = _schoolRepository.GetSchool().SchoolId;
            var studentSectionAssociation = new StudentSectionAssociation
            {
                SchoolId = schoolId,
                StudentUSI = setModel.StudentUsi,
                BeginDate = setModel.BeginDate,
                EndDate = setModel.EndDate,
                SchoolYear = section.SchoolYear,
                TermTypeId = section.TermTypeId,
                LocalCourseCode = section.LocalCourseCode,
                ClassPeriodName = section.ClassPeriodName,
                ClassroomIdentificationCode = section.ClassroomIdentificationCode
            };

            _genericRepository.Add(studentSectionAssociation);
            _genericRepository.Save();

            return new JsonResult();
        }

        //
        // AJAX POST: /GetSections/SCI4
        [HttpPost]
        public virtual JsonResult GetSections(string searchString)
        {
            var autoCompleteModels = GetAllSectionAutocompleteModelsWith(searchString);
            return Json(autoCompleteModels, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Models.Section.AutocompleteModel> GetAllSectionAutocompleteModelsWith(string searchString)
        {
            var sections = _genericRepository.GetAll<Section>().Where(s => s.UniqueSectionCode.ToLower().Contains(searchString.ToLower()));
            var autocompleteModels = sections.Select(section => _sectionToAutocompleteModelMapper.Build(section)).ToList();

            return autocompleteModels;
        }

        private List<SessionListItemModel> GetAllSessionModels()
        {
            var sessions = _genericRepository.GetAll<Session>();
            return sessions.Select(session => _sessionToSessionListItemModelMapper.Build(session)).ToList();
        }
	}
}