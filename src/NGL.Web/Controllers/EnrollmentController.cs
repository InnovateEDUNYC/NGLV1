using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Controllers
{
    public partial class EnrollmentController : Controller
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper<CreateStudentModel, Student> _enrollmentMapper;

        public EnrollmentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper)
        {
            _repository = repository;
            _enrollmentMapper = enrollmentMapper;
        }

        //
        // GET: /Enrollment/CreateStudent
        public virtual ActionResult CreateStudent()
        {
            var enrollmentModel = new CreateStudentModel
            {
                ParentEnrollmentInfoModel = new ParentEnrollmentInfoModel()
            };
            return View(enrollmentModel);
        }

        // POST: /Enrollment/CreateStudent
        [HttpPost]
        public virtual ActionResult CreateStudent(CreateStudentModel createStudentModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student();

                _enrollmentMapper.Map(createStudentModel, student);
                _repository.Add(student);
                _repository.Save();
                return RedirectToAction("All", "Student");
            }

            return View(createStudentModel);
        }
	}
}