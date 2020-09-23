using AssignmentSameIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSameIndex.Areas.Staff.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Staff/Trainer
        private string RoleCondition = "Trainer";
        public ActionResult Index(string Message = "")
        {
            ViewBag.Message = Message;
            return View(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(RoleCondition)).ToList());
        }

    }
}