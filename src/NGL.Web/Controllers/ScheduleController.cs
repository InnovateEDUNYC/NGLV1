using System.Web.Mvc;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using NGL.Web.Models.Schedule;

namespace NGL.Web.Controllers
{
    public partial class ScheduleController : Controller
    {
        //
        // GET: /Set/5
        public virtual ActionResult Set(int id)
        {
            var student = new Student();
//            var prof = 
//            var setModel = SetModel.CreateNewWith(student, sessionList);
            return View(new SetModel());
        }
	}
}