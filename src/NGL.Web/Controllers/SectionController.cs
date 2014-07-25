using System.Web.Mvc;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Controllers
{
    public partial class SectionController : Controller
    {
        private readonly IGenericRepository _genericRepository;

        public SectionController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //
        // GET: /Section/Create
        public virtual ActionResult Create()
        {
            return View();
        }

    }
}