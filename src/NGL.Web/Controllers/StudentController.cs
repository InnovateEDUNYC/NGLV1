using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper<Student, ProfileModel> _studentToDetailsModelMapper;
        private readonly IMapper<Student, IndexModel> _studentToStudentIndexModelMapper;
        private readonly AzureStorageUploader _fileUploader;

        public StudentController(IGenericRepository repository, IMapper<Student, ProfileModel> studentToDetailsModelMapper, IMapper<Student, IndexModel> studentToStudentIndexModelMapper, AzureStorageUploader fileUploader)
        {
            _repository = repository;
            _studentToDetailsModelMapper = studentToDetailsModelMapper;
            _studentToStudentIndexModelMapper = studentToStudentIndexModelMapper;
            _fileUploader = fileUploader;
        }

        // GET: /Student/All
        public virtual ActionResult All()
        {
            IEnumerable<Student> students = _repository.GetAll<Student>();
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
        // GET: /Student/5
        public virtual ActionResult Index(int usi)
        {
            var student = _repository.Get(
                new StudentByUsiQuery(usi),
                s => s.StudentAddresses,
                s => s.StudentRaces,
                s => s.StudentLanguages,
                s => s.StudentLanguages.Select(l => l.StudentLanguageUses),
                s => s.StudentParentAssociations.Select(p => p.Parent),
                s => s.StudentParentAssociations.Select(p => p.Parent.ParentAddresses),
                s => s.StudentParentAssociations.Select(p => p.Parent.ParentTelephones),
                s => s.StudentParentAssociations.Select(p => p.Parent.ParentElectronicMails),
                s => s.StudentAcademicDetails
            );

            if (student == null)
            {
                return HttpNotFound();
            }
            var profileModel = new ProfileModel();
            _studentToDetailsModelMapper.Map(student, profileModel);
            return View(profileModel);
        }

        //
        // POST: /Student/UploadPhoto/5
        public virtual ActionResult UploadPhoto(HttpPostedFileBase profilePhoto, int usi)
        {
            Upload(profilePhoto, usi + "/profilePhoto");
            return RedirectToAction(MVC.Student.Index(usi));
        }

        private void Upload(HttpPostedFileBase file, string relativePath)
        {
            if (file != null)
                _fileUploader.Upload(file, ConfigManager.StudentBlobContainer, relativePath);
        }

    }

}
