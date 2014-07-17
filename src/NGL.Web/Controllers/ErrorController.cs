using System.Web.Mvc;
using Antlr.Runtime.Misc;

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
            return Content("Caught a 404");
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