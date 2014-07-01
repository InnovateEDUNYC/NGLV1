using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;

namespace NGL.Web.Controllers
{
    public class StudentController : Controller
    {
        NglDbContext db = new NglDbContext();

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentModel enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(enrollmentModel);
        }

      }
}
