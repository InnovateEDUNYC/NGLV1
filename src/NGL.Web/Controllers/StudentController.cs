using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models;
using NGL.Web.Models.Student;
using Ninject.Extensions.Conventions.BindingGenerators;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private IGenericRepository _repository;
        private readonly IMapper<CreateStudentModel, Student> _enrollmentMapper;
        private readonly IMapper<Student, CreateStudentModel> _studentToCreateStudentModelMapper;
        private readonly IMapper<Student, StudentDetailsModel> _studentToDetailsModdelMapper;

        public StudentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper, IMapper<Student, CreateStudentModel> studentToCreateStudentModelMapper, IMapper<Student, StudentDetailsModel> studentToDetailsModdelMapper  )
        {
            _repository = repository;
            _enrollmentMapper = enrollmentMapper;
            _studentToCreateStudentModelMapper = studentToCreateStudentModelMapper;
            _studentToDetailsModdelMapper = studentToDetailsModdelMapper;
        }

        // GET: /Student
        public virtual ActionResult Index()
        {
            IEnumerable<Student> students = _repository.GetAll<Student>();
            var models = new List<CreateStudentModel>();

            foreach (var student in students)
            {
                var enrollmentModel = new CreateStudentModel();
                _studentToCreateStudentModelMapper.Map(student, enrollmentModel);
                models.Add(enrollmentModel);
            }

            return View(models);
        }

        //
        // GET: /Student/Create
        public virtual ActionResult Create()
        {
            var enrollmentModel = new CreateStudentModel();
            return View(enrollmentModel);
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public virtual ActionResult Create(CreateStudentModel createStudentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();

                _enrollmentMapper.Map(createStudentModel, student);
                _repository.Add<Student>(student);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View(createStudentModel);
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id = 0)
        {
            var student = _repository.Get(new StudentByUsiQuery(id));
            var detailsModel = new StudentDetailsModel();
            _studentToDetailsModdelMapper.Map(student, detailsModel);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(detailsModel);
        }

    }

}
