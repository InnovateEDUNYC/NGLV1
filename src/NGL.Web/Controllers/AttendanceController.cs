using System;
using System.Linq;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
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
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IGenericRepository genericRepository,
            ISectionRepository sectionRepository,
            SectionToTakeAttendanceModelMapper sectionToTakeAttendanceModelMapper,
            TakeAttendanceModelToStudentSectionAttendanceEventListMapper takeAttendanceModelToStudentSectionAttendanceEventListMapper, 
            IAttendanceService attendanceService)
        {
            _genericRepository = genericRepository;
            _sectionRepository = sectionRepository;
            _sectionToTakeAttendanceModelMapper = sectionToTakeAttendanceModelMapper;
            _takeAttendanceModelToStudentSectionAttendanceEventListMapper = takeAttendanceModelToStudentSectionAttendanceEventListMapper;
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [AuthorizeFor(Resource = "attendance", Operation = "create")]
        public virtual ActionResult Take()
        {
            return View(TakeAttendanceModel.CreateNew());
        }

        [HttpGet]
        [AuthorizeFor(Resource = "attendance", Operation = "create")]
        public virtual ActionResult GetStudents(TakeAttendanceModel takeAttendanceModel)
        {
            if (! ModelState.IsValid)
            {
                return View(MVC.Attendance.Views.Take, takeAttendanceModel);
            }

            var date = DateTime.Parse(takeAttendanceModel.Date);
            var section = _sectionRepository.GetWithStudentAttendance(takeAttendanceModel.SectionId.GetValueOrDefault());
            var takeAttendanceModelWithStudents = _sectionToTakeAttendanceModelMapper.Build(section, date);
            
            return View(MVC.Attendance.Views.Take, takeAttendanceModelWithStudents);
        }

        [HttpPost]
        [AuthorizeFor(Resource = "attendance", Operation = "create")]
        public virtual ActionResult Save(TakeAttendanceModel takeAttendanceModel)
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Attendance.Views.Take, takeAttendanceModel);
            }

            var section = _genericRepository.Get<Section>(s => s.SectionIdentity == takeAttendanceModel.SectionId, s => s.StudentSectionAssociations.Select(ssa => ssa.Student));
            
            var studentSectionAttendanceEventList =_takeAttendanceModelToStudentSectionAttendanceEventListMapper.Build(takeAttendanceModel, section);

            _attendanceService.RecordAttendanceFor(section, DateTime.Parse(takeAttendanceModel.Date), studentSectionAttendanceEventList);

            _genericRepository.Save();

            return RedirectToAction("GetStudents", takeAttendanceModel.Clone());
        }

        [HttpPost]
        [AuthorizeFor(Resource = "attendance", Operation = "clearAllFlags")]
        public virtual ActionResult ClearAllFlags()
        {
            _attendanceService.ClearAllFlags();
            _genericRepository.Save();

            TempData["ShowSuccess"] = true;
            return RedirectToAction(MVC.Student.All());
        }
    }
}