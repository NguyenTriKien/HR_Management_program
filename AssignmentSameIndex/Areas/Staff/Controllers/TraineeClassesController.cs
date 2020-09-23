using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentSameIndex.Models;

namespace AssignmentSameIndex.Areas.Staff.Controllers
{
    public class TraineeClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staff/TraineeClasses
        public ActionResult Index()
        {
            var traineeClasses = db.TraineeClasses.Include(t => t.Class).Include(t => t.Trainee);
            return View(traineeClasses.ToList());
        }

        // GET: Staff/TraineeClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            return View(traineeClass);
        }

        // GET: Staff/TraineeClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Code");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Staff/TraineeClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Grade,Note,ApplicationUserId,ClassId")] TraineeClass traineeClass)
        {
            if (ModelState.IsValid)
            {
                db.TraineeClasses.Add(traineeClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Code", traineeClass.ClassId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", traineeClass.ApplicationUserId);
            return View(traineeClass);
        }

        // GET: Staff/TraineeClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Code", traineeClass.ClassId);
            ViewBag.ApplicationUserId = new SelectList(db.
                Users, "Id", "Email", traineeClass.ApplicationUserId);
            return View(traineeClass);
        }

        // POST: Staff/TraineeClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Grade,Note,ApplicationUserId,ClassId")] TraineeClass traineeClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Code", traineeClass.ClassId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", traineeClass.ApplicationUserId);
            return View(traineeClass);
        }

        // GET: Staff/TraineeClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            return View(traineeClass);
        }

        // POST: Staff/TraineeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            db.TraineeClasses.Remove(traineeClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
