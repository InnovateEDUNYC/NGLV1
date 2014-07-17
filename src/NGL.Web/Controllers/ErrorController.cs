using System.Net;
using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult HttpError404()
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult General()
        {
            return View();
        }
    }
}