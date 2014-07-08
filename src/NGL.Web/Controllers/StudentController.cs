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
        private readonly IMapper<Student, ProfileModel> _studentToDetailsModdelMapper;
        private readonly IMapper<Student, IndexModel> _studentToStudentIndexModelMapper;

        public StudentController(IGenericRepository repository, IMapper<Student, ProfileModel> studentToDetailsModelMapper, IMapper<Student, IndexModel> studentToStudentIndexModelMapper)
        {
            _repository = repository;
            _studentToDetailsModdelMapper = studentToDetailsModelMapper;
            _studentToStudentIndexModelMapper = studentToStudentIndexModelMapper;
        }

        // GET: /Student
        public virtual ActionResult Index()
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
        // GET: /Student/Profile/5
        public virtual ActionResult Profile(int id = 0)
        {
            var student = _repository.Get(new StudentByUsiQuery(id));
            var profileModel = new ProfileModel();
            _studentToDetailsModdelMapper.Map(student, profileModel);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(profileModel);
        }

    }

}
