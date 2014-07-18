using System;
using System.Web;
using System.Web.Mvc;
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
        private readonly IMapper<AcademicDetailModel, StudentAcademicDetail> _academicDetailMapper;

        public EnrollmentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper,
            IMapper<EnterProgramStatusModel, StudentProgramStatus> programStatusMapper, IMapper<AcademicDetailModel, StudentAcademicDetail> academicDetailMapper, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _academicDetailMapper = academicDetailMapper;
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

            Func<string, string> makeUri = fileName => string.Format("{0}/{1}/{2}", id, "ProgramStatus", fileName);

            var specialEducationFileUri = UploadAndGetUriFor(enterProgramStatusModel.SpecialEducationFile,
                    makeUri("specialEducation"));
            var testingAccomodationFileUri = UploadAndGetUriFor(enterProgramStatusModel.TestingAccommodationFile, makeUri("testingAccomodation"));
            var titleParticipationFileUri = UploadAndGetUriFor(enterProgramStatusModel.TitleParticipationFile, makeUri("titleParticipation"));
            var mcKinneyVentoFileUri = UploadAndGetUriFor(enterProgramStatusModel.McKinneyVentoFile,
                makeUri("McKinneyVento"));

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
            return View(new AcademicDetailModel());
        }
        //
        // POST: /Enrollment/EnterAcademicHistory/id
        [HttpPost]
        public virtual ActionResult EnterAcademicHistory(AcademicDetailModel academicDetailModel, int id)
        {
            if (!ModelState.IsValid)
                return View(academicDetailModel);

//            string performanceHistoryFileUri = uploadAndGetUri;
            
                Func<string, string> makeUri = fileName => string.Format("{0}/{1}", id, fileName);

                var performanceHistoryFileUri = UploadAndGetUriFor(academicDetailModel.PerformanceHistoryFile,
                    makeUri("performanceHistory"));
                    

            StudentAcademicDetail studentAcademicDetail = _academicDetailMapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = id;
                    adm.PerformanceHistoryFileUrl = performanceHistoryFileUri;
                });

            _repository.Add(studentAcademicDetail);
            _repository.Save();
            return View();
        }

        private string UploadAndGetUriFor(HttpPostedFileBase file, string relativePath)
        {
            const string blobContainer = "student";
            if (file != null)
                return _fileUploader.Upload(file, blobContainer, relativePath);
          
            return null;
        }
    }
}