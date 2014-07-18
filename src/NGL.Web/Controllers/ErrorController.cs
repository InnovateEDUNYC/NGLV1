using System.Net;
using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public partial class ErrorController : Controller
    {
        public virtual ActionResult HttpError404()
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            Response.ContentType = "text/html";
            return View();
        }

        public virtual ActionResult General()
        {
            return View();
        }
    }
}