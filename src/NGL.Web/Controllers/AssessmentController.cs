using System.Web.Mvc;

namespace NGL.Web.Controllers
{
    public partial class AssessmentController : Controller
    {
        //
        // GET: /Assessment/Create
        public virtual ActionResult Create()
        {
            return View();
        }

    }
}