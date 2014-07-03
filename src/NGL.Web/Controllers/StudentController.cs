using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Student;
using Ninject.Extensions.Conventions.BindingGenerators;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private EnrollmentModelToStudentMapper _enrollmentModelToStudentMapper;
        private IGenericRepository _repository;

        public StudentController(IGenericRepository repository)
        {
            _enrollmentModelToStudentMapper = new EnrollmentModelToStudentMapper();
            _repository = repository;
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
                _enrollmentModelToStudentMapper.Map(enrollmentModel, student);
                _repository.Add<Student>(student);
                _repository.Save();
                return RedirectToAction("Create");
            }

            return View(enrollmentModel);
        }

    }

}
