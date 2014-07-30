using System;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
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
        private readonly IMapper<AcademicDetailModel, StudentSchoolAssociation> _schoolAssociationMapper;
        private readonly IMapper<AcademicDetailModel, StudentAcademicDetail> _academicDetailMapper;

        public EnrollmentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper,
                                                IMapper<EnterProgramStatusModel, StudentProgramStatus> programStatusMapper, 
                                                IMapper<AcademicDetailModel, StudentAcademicDetail> academicDetailMapper, 
                                                IFileUploader fileUploader,
                                                IMapper<AcademicDetailModel, 
                                                StudentSchoolAssociation> schoolAssociationMapper)
        {
            _fileUploader = fileUploader;
            _schoolAssociationMapper = schoolAssociationMapper;
            _academicDetailMapper = academicDetailMapper;
            _repository = repository;
            _enrollmentMapper = enrollmentMapper;
            _programStatusMapper = programStatusMapper;
        }

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
            return RedirectToAction(MVC.Enrollment.EnterAcademicDetails((int) createStudentModel.StudentUsi));
        }

        // GET: /Enrollment/EnterAcademicDetails/id
        public virtual ActionResult EnterAcademicDetails(int id)
        {
            var model = new AcademicDetailModel{StudentUsi = id};
            
            if (StudentDoesNotExist(id))
                return RedirectToAction(MVC.Error.General());

            return View(model);
        }

        private bool StudentDoesNotExist(int id)
        {
            return _repository.Get(new StudentByUsiQuery(id)) == null;
        }

        // POST: /Enrollment/EnterAcademicDetails/id
        [HttpPost]
        public virtual ActionResult EnterAcademicDetails(AcademicDetailModel academicDetailModel, int id)
        {
            if (!ModelState.IsValid)
                return View(academicDetailModel);

            var fileCategory = ((int)academicDetailModel.SchoolYear).ToString();
            var performanceHistoryFileName = Upload(academicDetailModel.PerformanceHistoryFile, id, fileCategory, "performanceHistory");
                    
            var studentAcademicDetail = _academicDetailMapper.Build(academicDetailModel,
                adm =>
                {
                    adm.StudentUSI = id;
                    adm.PerformanceHistoryFile = performanceHistoryFileName;
                });

            var studentSchoolAssociation = _schoolAssociationMapper.Build(academicDetailModel);

            _repository.Add(studentAcademicDetail);
            _repository.Add(studentSchoolAssociation);
            _repository.Save();
            return RedirectToAction(MVC.Enrollment.EnterProgramStatus(id));
        }

        // GET: /Enrollment/EnterProgramStatus/id
        public virtual ActionResult EnterProgramStatus(int id)
        {
            if (StudentDoesNotExist(id))
               return RedirectToAction(MVC.Error.General());
            return View();
        }

        // POST: /Enrollment/EnterProgramStatus/id
        [HttpPost]
        public virtual ActionResult EnterProgramStatus(EnterProgramStatusModel enterProgramStatusModel, int id)
        {
            if (!ModelState.IsValid)
                return View(enterProgramStatusModel);

            var specialEducationFileName = Upload(enterProgramStatusModel.SpecialEducationFile, id, "ProgramStatus", "specialEducation");
            var testingAccomodationFileName = Upload(enterProgramStatusModel.TestingAccommodationFile, id, "ProgramStatus", "testingAccomodation");
            var titleParticipationFileName = Upload(enterProgramStatusModel.TitleParticipationFile, id, "ProgramStatus", "titleParticipation");
            var mcKinneyVentoFileName = Upload(enterProgramStatusModel.McKinneyVentoFile, id, "ProgramStatus", "mcKinneyVento");

            var studentProgramStatus = _programStatusMapper.Build(enterProgramStatusModel,
                psm =>
                {
                    psm.StudentUSI = id;
                    psm.TitleParticipationFile = titleParticipationFileName;
                    psm.TestingAccommodationFile = testingAccomodationFileName;
                    psm.SpecialEducationFile = specialEducationFileName;
                    psm.McKinneyVentoFile = mcKinneyVentoFileName;
                });

            _repository.Add(studentProgramStatus);
            _repository.Save();
            return RedirectToAction(MVC.Student.Index(id));
        }

        private string Upload(HttpPostedFileBase file, int studentUSI, string fileCategory, string fileName)
        {
            if (file == null) return null;

            Func<string, string> makeRelativeFilePathFor = name => string.Format("{0}/{1}/{2}", studentUSI, fileCategory, name);
            var relativePath = makeRelativeFilePathFor(fileName);

            _fileUploader.Upload(file.InputStream, ConfigManager.StudentBlobContainer, relativePath);
            return relativePath;
        }
    }
}