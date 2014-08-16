using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Attendance;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class AttendanceController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionToTakeAttendanceModelMapper _sectionToTakeAttendanceModelMapper;
        private readonly TakeAttendanceModelToStudentSectionAttendanceEventListMapper _takeAttendanceModelToStudentSectionAttendanceEventListMapper;
        private IAttendanceRepository _attendanceRepository;

        public AttendanceController(IGenericRepository genericRepository,
            ISectionRepository sectionRepository,
            IAttendanceRepository attendanceRepository,
            SectionToTakeAttendanceModelMapper sectionToTakeAttendanceModelMapper,
            TakeAttendanceModelToStudentSectionAttendanceEventListMapper takeAttendanceModelToStudentSectionAttendanceEventListMapper)
        {
            _genericRepository = genericRepository;
            _sectionRepository = sectionRepository;
            _attendanceRepository = attendanceRepository;
            _sectionToTakeAttendanceModelMapper = sectionToTakeAttendanceModelMapper;
            _takeAttendanceModelToStudentSectionAttendanceEventListMapper = takeAttendanceModelToStudentSectionAttendanceEventListMapper;
        }

        [HttpGet]
        public virtual ActionResult Take()
        {
            return View(TakeAttendanceModel.CreateNew());
        }

        [HttpGet]
        public virtual ActionResult GetStudents(int? sectionId, string date)
        {
            DateTime dateTime;
            var isValidDate = DateTime.TryParse(date, out dateTime);
            if (!sectionId.HasValue || !isValidDate)
            {
                return View(MVC.Attendance.Views.Take, new TakeAttendanceModel {SectionId = sectionId, Date = dateTime});
            }

            var section = _sectionRepository.GetWithStudentAssociationsForDate(sectionId.Value, dateTime);
            var existingAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, dateTime);

            var takeAttendanceModel = _sectionToTakeAttendanceModelMapper.Build(section, existingAttendanceEvents, dateTime);
            
            return View(MVC.Attendance.Views.Take, takeAttendanceModel);
        }

        [HttpPost]
        public virtual ActionResult GetStudents(TakeAttendanceModel takeAttendanceModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == takeAttendanceModel.SectionId);
            var currentAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, takeAttendanceModel.Date);

            if (!currentAttendanceEvents.IsNullOrEmpty())
                _attendanceRepository.Delete(currentAttendanceEvents);

            CreateAttendanceEvents(takeAttendanceModel, section);
            
            _genericRepository.Save();

            return RedirectToAction(MVC.Attendance.Take());
        }

        private void CreateAttendanceEvents(TakeAttendanceModel takeAttendanceModel, Section section)
        {
            var studentSectionAttendanceEventList =
                _takeAttendanceModelToStudentSectionAttendanceEventListMapper.Build(takeAttendanceModel, section);

            _attendanceRepository.AddStudentSectionAttendanceEventList(studentSectionAttendanceEventList);
        }
    }
}