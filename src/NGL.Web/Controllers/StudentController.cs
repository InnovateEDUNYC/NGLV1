using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.ImageTools;
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
        private readonly IMapper<StudentBiographicalInformationModel, Student> _studentBiographicalInfoToStudentMapper;

        public StudentController(IGenericRepository repository, IMapper<Student, ProfileModel> studentToProfileModelMapper,
                                                IMapper<Student, IndexModel> studentToStudentIndexModelMapper,
                                                AzureStorageUploader fileUploader, IStudentRepository studentRepository,
                                IMapper<StudentBiographicalInformationModel, Student> studentBiographicalInfoToStudentMapper)
        {
            _repository = repository;
            _studentToProfileModelMapper = studentToProfileModelMapper;
            _studentToStudentIndexModelMapper = studentToStudentIndexModelMapper;
            _fileUploader = fileUploader;
            _studentRepository = studentRepository;
            _studentBiographicalInfoToStudentMapper = studentBiographicalInfoToStudentMapper;
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
                var photoStream = Resizer.ScaleImage(profilePhoto.InputStream, 200, 200);
                var thumbNailStream = Resizer.ScaleImage(profilePhoto.InputStream, 50, 50);

                Upload(photoStream, usi + "/profilePhoto");
                Upload(thumbNailStream, usi + "/profileThumbnail");
            }
            catch (ArgumentException ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return RedirectToAction(MVC.Student.Index(usi));
        }

        [HttpPost]
        public virtual JsonResult EditBiographicalInfo(StudentBiographicalInformationModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return Json(new { errors }, JsonRequestBehavior.AllowGet);
            }

            var student = _studentRepository.GetByUSI(model.StudentUsi);
            _studentBiographicalInfoToStudentMapper.Map(model, student);
            _repository.Save();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private void Upload(Stream file, string relativePath)
        {
            if (file != null)
                _fileUploader.Upload(file, ConfigManager.StudentBlobContainer, relativePath);
        }
    }
}
