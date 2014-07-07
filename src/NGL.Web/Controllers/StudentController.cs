using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models;
using NGL.Web.Models.Student;
using Ninject.Extensions.Conventions.BindingGenerators;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private IGenericRepository _repository;
        private readonly IMapper<EnrollmentModel, Student> _enrollmentMapper;
        private readonly IMapper<Student, EnrollmentModel> _studentToEnrollmentModelMapper;

        public StudentController(IGenericRepository repository, IMapper<EnrollmentModel, Student> enrollmentMapper, IMapper<Student, EnrollmentModel> studentToEnrollmentModelMapper )
        {
            _repository = repository;
            _enrollmentMapper = enrollmentMapper;
            _studentToEnrollmentModelMapper = studentToEnrollmentModelMapper;
        }

        // GET: /Student
        public virtual ActionResult Index()
        {
            IEnumerable<Student> students = _repository.GetAll<Student>();
            var models = new List<EnrollmentModel>();

            foreach (var student in students)
            {
                var enrollmentModel = new EnrollmentModel();
                _studentToEnrollmentModelMapper.Map(student, enrollmentModel);
                models.Add(enrollmentModel);
            }

            return View(models);
        }

        //
        // GET: /Student/Create
        public virtual ActionResult Create()
        {
            var enrollmentModel = new EnrollmentModel();
            return View(enrollmentModel);
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public virtual ActionResult Create(EnrollmentModel enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();

                _enrollmentMapper.Map(enrollmentModel, student);
                _repository.Add<Student>(student);
                _repository.Save();
                return RedirectToAction("Create");
            }

            return View(enrollmentModel);
        }

    }

}
