using System.Net;
using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public partial class ErrorController : Controller
    {
        public virtual ActionResult HttpError404()
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            return View();
        }

        public virtual ActionResult General()
        {
            return View();
        }
    }
}