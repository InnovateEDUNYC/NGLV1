using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Attendance;
using NGL.Web.Service;

namespace NGL.Web.Controllers
{
    public partial class AttendanceController : Controller
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionToTakeAttendanceModelMapper _sectionToTakeAttendanceModelMapper;
        private readonly TakeAttendanceModelToStudentSectionAttendanceEventListMapper _takeAttendanceModelToStudentSectionAttendanceEventListMapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IGenericRepository genericRepository,
            ISectionRepository sectionRepository,
            IAttendanceRepository attendanceRepository,
            SectionToTakeAttendanceModelMapper sectionToTakeAttendanceModelMapper,
            TakeAttendanceModelToStudentSectionAttendanceEventListMapper takeAttendanceModelToStudentSectionAttendanceEventListMapper, 
            IAttendanceService attendanceService)
        {
            _genericRepository = genericRepository;
            _sectionRepository = sectionRepository;
            _attendanceRepository = attendanceRepository;
            _sectionToTakeAttendanceModelMapper = sectionToTakeAttendanceModelMapper;
            _takeAttendanceModelToStudentSectionAttendanceEventListMapper = takeAttendanceModelToStudentSectionAttendanceEventListMapper;
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public virtual ActionResult Take()
        {
            return View(TakeAttendanceModel.CreateNew());
        }

        [HttpGet]
        public virtual ActionResult GetStudents(TakeAttendanceModel takeAttendanceModel)
        {
            if (! ModelState.IsValid)
            {
                return View(MVC.Attendance.Views.Take, takeAttendanceModel);
            }

            //todo - make them a single call to sectionRepo
            var section = _sectionRepository.GetWithStudentAssociationsForDate(takeAttendanceModel.SectionId.Value, takeAttendanceModel.Date);
            var existingAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, takeAttendanceModel.Date);

            var takeAttendanceModelWithStudents = _sectionToTakeAttendanceModelMapper.Build(section, existingAttendanceEvents, takeAttendanceModel.Date);
            
            return View(MVC.Attendance.Views.Take, takeAttendanceModelWithStudents);
        }

        [HttpPost]
        public virtual ActionResult Save(TakeAttendanceModel takeAttendanceModel)
        {
            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == takeAttendanceModel.SectionId);
            var studentSectionAttendanceEventList =_takeAttendanceModelToStudentSectionAttendanceEventListMapper.Build(takeAttendanceModel, section);

            _attendanceService.RecordAttendanceFor(section, takeAttendanceModel.Date, studentSectionAttendanceEventList);

            _genericRepository.Save();

            return RedirectToAction("GetStudents", takeAttendanceModel.Clone());
        }
    }
}