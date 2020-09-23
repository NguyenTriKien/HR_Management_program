using AssignmentSameIndex.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
namespace AssignmentSameIndex.Areas.Trainee
{
    public class InfoController : Controller
    {
        // GET: Staff/Info
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Details()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            
            return View(user);
        }
    }
}