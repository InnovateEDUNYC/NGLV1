using System.Web.Mvc;
using Antlr.Runtime.Misc;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using NGL.Web.Models.Enrollment.Parent;
using NGL.Web.Models.Enrollment.Student;

namespace NGL.Web.Controllers
{
	public partial class EnrollmentController : Controller
	{
		private readonly IGenericRepository _repository;
		private readonly IMapper<CreateStudentModel, Student> _enrollmentMapper;
		private readonly IMapper<EnterProgramStatusModel, StudentProgramStatus> _programStatusMapper;
		private readonly IFileUploader _fileUploader;
        private readonly CreateStudentModelValidator _validator;

		public EnrollmentController(IGenericRepository repository, IMapper<CreateStudentModel, Student> enrollmentMapper, 
			IMapper<EnterProgramStatusModel, StudentProgramStatus> programStatusMapper, CreateStudentModelValidator validator)
		{
			_fileUploader = new AzureStorageUploader();
			_repository = repository;
			_enrollmentMapper = enrollmentMapper;
			_programStatusMapper = programStatusMapper;
			_validator = validator;
		}

        //
        // GET: /Enrollment/CreateStudent
        public virtual ActionResult CreateStudent()
        {
            var enrollmentModel = new CreateStudentModel
            {

                FirstParent = new ParentEnrollmentInfoModel
                {
                    SameAddressAsStudent = true
                }
			};
            return View(enrollmentModel);
		}
		// POST: /Enrollment/CreateStudent
		[HttpPost]
		public virtual ActionResult CreateStudent(CreateStudentModel createStudentModel)
		{
			if (!ModelState.IsValid) 
				return View(createStudentModel);
                
            

			var student = new Student();

			_enrollmentMapper.Map(createStudentModel, student);
			_repository.Add(student);
			_repository.Save();
		    return RedirectToAction("All", "Student");
		}

		public virtual ActionResult EnterProgramStatus(int id)
		{
			return View();
		}

		[HttpPost]
		public virtual ActionResult EnterProgramStatus(EnterProgramStatusModel enterProgramStatusModel, int id)
		{
			if (!ModelState.IsValid)
				return View(enterProgramStatusModel);

			Func<string, string> getUri = fileName => string.Format("{0}/{1}/{2}", id, "ProgramStatus", fileName);
			const string blobContainer = "student";

			var specialEducationFileUri = _fileUploader.Upload(enterProgramStatusModel.SpecialEducationFile, blobContainer, getUri("specialEducation"));
			var testingAccomodationFileUri = _fileUploader.Upload(enterProgramStatusModel.TestingAccommodationFile, blobContainer, getUri("testingAccomodation"));
			var titleParticipationFileUri = _fileUploader.Upload(enterProgramStatusModel.TitleParticipationFile, blobContainer, getUri("titleParticipation"));
			var mcKinneyVentoFileUri = _fileUploader.Upload(enterProgramStatusModel.McKinneyVentoFileUrl, blobContainer, getUri("McKinneyVento"));

			var studentProgramStatus = _programStatusMapper.Build(enterProgramStatusModel,
				psm =>
				{
                    psm.StudentUSI = id;
					psm.TitleParticipationFileUrl = titleParticipationFileUri;
					psm.TestingAccommodationFileUrl = testingAccomodationFileUri;
					psm.SpecialEducationFileUrl = specialEducationFileUri;
					psm.McKinneyVentoFileUrl = mcKinneyVentoFileUri;
				});

			_repository.Add(studentProgramStatus);
			_repository.Save();
			return RedirectToAction("Home", "Index");
		}
	}

}