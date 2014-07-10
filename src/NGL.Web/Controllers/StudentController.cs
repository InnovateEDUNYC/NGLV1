using System.Collections.Generic;
using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public partial class StudentController : Controller
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper<Student, ProfileModel> _studentToDetailsModelMapper;
        private readonly IMapper<Student, IndexModel> _studentToStudentIndexModelMapper;

        public StudentController(IGenericRepository repository, IMapper<Student, ProfileModel> studentToDetailsModelMapper, IMapper<Student, IndexModel> studentToStudentIndexModelMapper)
        {
            _repository = repository;
            _studentToDetailsModelMapper = studentToDetailsModelMapper;
            _studentToStudentIndexModelMapper = studentToStudentIndexModelMapper;
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
            var student = _repository.Get(new StudentByUsiQuery(usi));
            if (student == null)
            {
                return HttpNotFound();
            }
            var profileModel = new ProfileModel();
            _studentToDetailsModelMapper.Map(student, profileModel);
            return View(profileModel);
        }

    }

}
