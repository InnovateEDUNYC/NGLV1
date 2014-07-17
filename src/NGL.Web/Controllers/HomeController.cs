using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    [AllowAnonymous]
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Scheduling()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}