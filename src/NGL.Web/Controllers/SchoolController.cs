using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public class SchoolController : Controller
    {
        public SchoolController()
        {
        }

        //
        // GET: /School/
        public ActionResult Index()
        {
            return View();
        }
	}
}