using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models;
using NGL.Web.Models.Attendance;

namespace NGL.Web.Controllers
{
    public partial class AttendanceController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper<Section, TakeAttendanceModel> _sectionToTakeAttendanceModelMapper;
        private readonly TakeAttendanceModelToStudentSectionAttendanceEventListMapper _takeAttendanceModelToStudentSectionAttendanceEventListMapper;

        public AttendanceController(IGenericRepository genericRepository,
            ISectionRepository sectionRepository,
            IMapper<Section, TakeAttendanceModel> sectionToTakeAttendanceModelMapper,
            TakeAttendanceModelToStudentSectionAttendanceEventListMapper takeAttendanceModelToStudentSectionAttendanceEventListMapper)
        {
            _genericRepository = genericRepository;
            _sectionRepository = sectionRepository;
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
            var takeAttendanceModel = _sectionToTakeAttendanceModelMapper.Build(section);
            takeAttendanceModel.Date = dateTime;
            
            return View(MVC.Attendance.Views.Take, takeAttendanceModel);
        }

        [HttpPost]
        public virtual ActionResult GetStudents(TakeAttendanceModel takeAttendanceModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == takeAttendanceModel.SectionId);
            var studentSectionAttendanceEventList =
                _takeAttendanceModelToStudentSectionAttendanceEventListMapper.Build(takeAttendanceModel, section);

            foreach (var ssae in studentSectionAttendanceEventList)
            {
                _genericRepository.Add(ssae);
            }
            _genericRepository.Save();

            return RedirectToAction(MVC.Attendance.Take());
        }
    }
}