using System.Web.Mvc;
using NGL.Web.Infrastructure.Security;

namespace NGL.Web.Controllers
{
    public partial class CourseGenerationController : Controller
    {
        //
        // GET: /CourseGeneration/
        [AuthorizeFor(Resource = "courseGeneration", Operation = "view")]
        public virtual ActionResult Index()
        {
            return View();
        }
	}
}