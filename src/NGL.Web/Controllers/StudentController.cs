using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Extensions;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper<Student, ProfileModel> _studentToProfileModelMapper;
        private readonly IMapper<Student, IndexModel> _studentToStudentIndexModelMapper;
        private readonly AzureStorageUploader _fileUploader;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper<EditableStudentBiographicalInfoModel, Student> _studentBiographicalInfoToStudentMapper;
        private readonly IMapper<NameModel, Student> _studentNameToStudentMapper;
        private readonly IMapper<HomeAddressModel, StudentAddress> _studentHomeAddressToStudentMapper;
        private readonly IParentRepository _parentRepository;
        private readonly IMapper<EditProfileParentModel, Parent> _editProfileParentModelToParentMapper;
        private readonly ProgramStatusModelToProgramStatusForEditMapper _programStatusModelToProgramStatusForEditMapper;
        private readonly EditAcademicDetailModelToStudentAcademicDetailMapper _editAcademicDetailModelToStudentAcademicDetailMapper;

        public StudentController(IGenericRepository repository, 
            IMapper<Student, ProfileModel> studentToProfileModelMapper,
            IMapper<Student, IndexModel> studentToStudentIndexModelMapper,
            IMapper<NameModel, Student> studentNameToStudentMapper, 
            IMapper<HomeAddressModel, StudentAddress> studentHomeAddressToStudentMapper,
            AzureStorageUploader fileUploader, IStudentRepository studentRepository,
            IMapper<EditableStudentBiographicalInfoModel, Student> studentBiographicalInfoToStudentMapper, 
            IParentRepository parentRepository, 
            IMapper<EditProfileParentModel, Parent> editProfileParentModelToParentMapper,
            ProgramStatusModelToProgramStatusForEditMapper programStatusModelToProgramStatusForEditMapper, 
			EditAcademicDetailModelToStudentAcademicDetailMapper editAcademicDetailModelToStudentAcademicDetailMapper)
        {
            _repository = repository;
            _studentToProfileModelMapper = studentToProfileModelMapper;
            _studentToStudentIndexModelMapper = studentToStudentIndexModelMapper;
            _fileUploader = fileUploader;
            _studentRepository = studentRepository;
            _studentBiographicalInfoToStudentMapper = studentBiographicalInfoToStudentMapper;
            _studentNameToStudentMapper = studentNameToStudentMapper;
            _studentHomeAddressToStudentMapper = studentHomeAddressToStudentMapper;
            _parentRepository = parentRepository;
            _editProfileParentModelToParentMapper = editProfileParentModelToParentMapper;
            _programStatusModelToProgramStatusForEditMapper = programStatusModelToProgramStatusForEditMapper;
            _editAcademicDetailModelToStudentAcademicDetailMapper = editAcademicDetailModelToStudentAcademicDetailMapper;
        }

        // GET: /Student/All
        [AuthorizeFor(Resource = "enrollment", Operation = "view")]
        public virtual ActionResult All()
        {
            var students = _repository.GetAll<Student>().ToList();
            var models = new List<IndexModel>();

            foreach (var student in students)
            {
                var indexModel = new IndexModel();
                _studentToStudentIndexModelMapper.Map(student, indexModel);
                models.Add(indexModel);
            }

            return View(models);
        }

        //
        // GET: /Student/Reports
        [AuthorizeFor(Resource = "assessment", Operation = "view")]
        public virtual ActionResult Reports()
        {
            IEnumerable<Student> students = _repository.GetAll<Student>().ToList();
            var models = new List<IndexModel>();

            foreach (var student in students)
            {
                var indexModel = new IndexModel();
                _studentToStudentIndexModelMapper.Map(student, indexModel);
                models.Add(indexModel);
            }

            return View(models);
        }

        // GET: /Student/5
        [AuthorizeFor(Resource = "enrollment", Operation = "view")]
        public virtual ActionResult Index(int usi)
        {
            var student = _studentRepository.GetByUSI(usi);

            if (student == null)
                return HttpNotFound();

            var profileModel = _studentToProfileModelMapper.Build(student);
            return View(profileModel);
        }

        // POST: /Student/UploadPhoto/5
        [AuthorizeFor(Resource = "enrollment", Operation = "edit")]
        public virtual ActionResult UploadPhoto(HttpPostedFileBase profilePhoto, int usi)
        {
            try
            {
                _fileUploader.UploadProfilePhoto(usi, profilePhoto);
            }
            catch (ArgumentException ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return RedirectToAction(MVC.Student.Index(usi));
        }

        [HttpPost]
        public virtual JsonResult EditBiographicalInfo(EditableStudentBiographicalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                var nglErrors = ModelState.GetNglErrors();
                return Json(new { nglErrors }, JsonRequestBehavior.AllowGet);
            }

            var student = _studentRepository.GetByUSI(model.StudentUsi);
            _studentBiographicalInfoToStudentMapper.Map(model, student);
           
            _repository.Save();

            TempData["ShowSuccess"] = true;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult EditStudentName(NameModel model)
        {
            if (!ModelState.IsValid)
            {
                var nglErrors = ModelState.GetNglErrors();
                return Json(new { nglErrors }, JsonRequestBehavior.AllowGet);
            }

            var student = _studentRepository.GetByUSI(model.StudentUsi);
            _studentNameToStudentMapper.Map(model, student);

            _repository.Save();

            TempData["ShowSuccess"] = true;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult EditHomeAddress(HomeAddressModel model)
        {
            if (!ModelState.IsValid)
            {
                var nglErrors = ModelState.GetNglErrors();
                return Json(new { nglErrors }, JsonRequestBehavior.AllowGet);
            }

            var student = _studentRepository.GetByUSI(model.StudentUsi);
            var address = student.StudentAddresses.First();

            _studentHomeAddressToStudentMapper.Map(model, address);

            _repository.Save();

            TempData["ShowSuccess"] = true;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual JsonResult EditParentInfo(EditProfileParentModel model)
        {
            if (!ModelState.IsValid)
            {
                var nglErrors = ModelState.GetNglErrors();

                return Json(new { nglErrors }, JsonRequestBehavior.AllowGet);
            }

            var parent = _parentRepository.GetByUSI(model.ParentUSI);
            _editProfileParentModelToParentMapper.Map(model, parent);
            _repository.Save();

            TempData["ShowSuccess"] = true;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult EditProgramStatus(int studentUsi, EnterProgramStatusModel programStatus)
        {
            var specialEducationFileName = _fileUploader.Upload(programStatus.SpecialEducationFile, studentUsi, "ProgramStatus", "specialEducation");
            var testingAccomodationFileName = _fileUploader.Upload(programStatus.TestingAccommodationFile, studentUsi, "ProgramStatus", "testingAccomodation");
            var titleParticipationFileName = _fileUploader.Upload(programStatus.TitleParticipationFile, studentUsi, "ProgramStatus", "titleParticipation");
            var mcKinneyVentoFileName = _fileUploader.Upload(programStatus.McKinneyVentoFile, studentUsi, "ProgramStatus", "mcKinneyVento");

            var filePaths = new ProgramStatusUploadedFilePaths(specialEducationFileName, testingAccomodationFileName,
                titleParticipationFileName, mcKinneyVentoFileName);

            var studentProgramStatus = _repository.Get<StudentProgramStatus>(sps => sps.StudentUSI == studentUsi);
            _programStatusModelToProgramStatusForEditMapper.Map(programStatus, studentProgramStatus, filePaths);

            _repository.Save();
            
            TempData["ShowSuccess"] = true;
            return RedirectToAction(MVC.Student.Index(studentUsi));
        }

        [HttpPost]
        public virtual ActionResult EditAcademicDetails(int studentUsi, EditAcademicDetailModel academicDetail)
        {
            if (!ModelState.IsValid)
            {
                TempData["ShowSuccess"] = false;
                return RedirectToAction(MVC.Student.Index(studentUsi));
            }

            var fileCategory = academicDetail.SchoolYear.ToString(CultureInfo.InvariantCulture);
            var performanceHistoryFileName = _fileUploader.Upload(academicDetail.PerformanceHistoryFileUrl, studentUsi, fileCategory, "performanceHistory");

            var student = _studentRepository.GetByUSI(studentUsi);
            var studentAcademicDetail = student.StudentAcademicDetails.First();

            _editAcademicDetailModelToStudentAcademicDetailMapper.Map(academicDetail, studentAcademicDetail, performanceHistoryFileName);

            _repository.Save();

            TempData["ShowSuccess"] = true;
            return RedirectToAction(MVC.Student.Index(studentUsi));
        }

        [HttpPost]
        public virtual JsonResult ValidateEditedAcademicDetails(EditAcademicDetailModel AcademicDetail)
        {
            if (!ModelState.IsValid)
            {
                var nglErrors = ModelState.GetNglErrors();

                return Json(new { nglErrors }, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
