using System.Net;
using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return Content("Generic Error");
        }

        public ActionResult HttpError404()
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult HttpError500()
        {
            return Content("Caught a 500");
        }

        public ActionResult General()
        {
            return Content("Caught a general http error");
        }
    }
}