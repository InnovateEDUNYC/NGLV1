using System;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Controllers
{
    public partial class EnrollmentController : Controller
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper<CreateStudentModel, Student> _enrollmentMapper;
        private readonly IMapper<EnterProgramStatusModel, StudentProgramStatus> _programStatusMapper;
        private readonly IFileUploader _fileUploader;

        public EnrollmentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper,
            IMapper<EnterProgramStatusModel, StudentProgramStatus> programStatusMapper, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _repository = repository;
            _enrollmentMapper = enrollmentMapper;
            _programStatusMapper = programStatusMapper;
        }

        //
        // GET: /Enrollment/CreateStudent
        public virtual ActionResult CreateStudent()
        {
            return View(CreateStudentModel.New());
        }

        // POST: /Enrollment/CreateStudent
        [HttpPost]
        public virtual ActionResult CreateStudent(CreateStudentModel createStudentModel)
        {
            if (!ModelState.IsValid)
                return View(createStudentModel);

            var student = new Student();

            _enrollmentMapper.Map(createStudentModel, student);
            _repository.Add(student);
            _repository.Save();
            return RedirectToAction(MVC.Student.All());
        }

        public virtual ActionResult EnterProgramStatus(int id)
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult EnterProgramStatus(EnterProgramStatusModel enterProgramStatusModel, int id)
        {
            if (!ModelState.IsValid)
                return View(enterProgramStatusModel);

            Func<string, string> getUri = fileName => string.Format("{0}/{1}/{2}", id, "ProgramStatus", fileName);
            const string blobContainer = "student";

            var specialEducationFileUri = _fileUploader.Upload(enterProgramStatusModel.SpecialEducationFile,
                blobContainer, getUri("specialEducation"));
            var testingAccomodationFileUri = _fileUploader.Upload(enterProgramStatusModel.TestingAccommodationFile,
                blobContainer, getUri("testingAccomodation"));
            var titleParticipationFileUri = _fileUploader.Upload(enterProgramStatusModel.TitleParticipationFile,
                blobContainer, getUri("titleParticipation"));
            var mcKinneyVentoFileUri = _fileUploader.Upload(enterProgramStatusModel.McKinneyVentoFile, blobContainer,
                getUri("McKinneyVento"));

            var studentProgramStatus = _programStatusMapper.Build(enterProgramStatusModel,
                psm =>
                {
                    psm.StudentUSI = id;
                    psm.TitleParticipationFileUrl = titleParticipationFileUri;
                    psm.TestingAccommodationFileUrl = testingAccomodationFileUri;
                    psm.SpecialEducationFileUrl = specialEducationFileUri;
                    psm.McKinneyVentoFileUrl = mcKinneyVentoFileUri;
                });

            _repository.Add(studentProgramStatus);
            _repository.Save();
            return RedirectToAction("Index", "Home");
        }


        //
        // GET: /Enrollment/EnterAcademicHistory/id
        public virtual ActionResult EnterAcademicHistory(int id)
        {
            return View(new AcademicHistoryModel());
        }
        //
        // POST: /Enrollment/EnterAcademicHistory/id
        [HttpPost]
        public virtual ActionResult EnterAcademicHistory(AcademicHistoryModel academicHistoryModel, int id)
        {
            if (!ModelState.IsValid)
                return View(academicHistoryModel);

            Func<string, string> getUri = fileName => string.Format("{0}/{1}/{2}/{3}", id, "AcademicHistory", academicHistoryModel.SchoolYear, fileName);
            const string blobContainer = "student";

            var performanceHistoryFile = _fileUploader.Upload(academicHistoryModel.PerformanceHistoryFile,
                blobContainer, getUri("performanceHistory"));

            return View();
        }

        // POST: /Enrollment/EnterAcademicHistory
//		[HttpPost]
//		public virtual ActionResult CreateStudent(CreateStudentModel createStudentModel)
//		{
//			if (!ModelState.IsValid) 
//				return View(createStudentModel);
//
//			var student = new Student();
//
//			_enrollmentMapper.Map(createStudentModel, student);
//			_repository.Add(student);
//			_repository.Save();
//		    return RedirectToAction(MVC.Student.All());
//		}
    }
}