using AssignmentSameIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSameIndex.Areas.Staff.Controllers
{
    public class TraineeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Staff/Trainee
        private string RoleCondition = "Trainee";
        public ActionResult Index(string Message = "")
        {
            ViewBag.Message = Message;
            return View(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(RoleCondition)).ToList());
        }

    }
}