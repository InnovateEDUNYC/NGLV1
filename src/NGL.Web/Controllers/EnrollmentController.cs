using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Student;

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
            var enrollmentModel = new CreateStudentModel();
            return View(enrollmentModel);
        }

        // POST: /Enrollment/CreateStudent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public virtual ActionResult CreateStudent(CreateStudentModel createStudentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();

                _enrollmentMapper.Map(createStudentModel, student);
                _repository.Add<Student>(student);
                _repository.Save();
                return RedirectToAction("All", "Student");
            }

            return View(createStudentModel);
        }
	}
}