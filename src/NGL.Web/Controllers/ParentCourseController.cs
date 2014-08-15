using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Controllers
{
    public partial class ParentCourseController : Controller
    {
        //
        // GET: /ParentCourse/
        public virtual ActionResult Index()
        {
            var parentCourses = new List<IndexModel>();
            return View(parentCourses);
        }

        //
        // GET: /ParentCourse/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ParentCourse/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ParentCourse/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
