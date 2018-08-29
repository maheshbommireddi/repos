using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint_Zero.Models;

namespace Sprint_Zero.Controllers
{
    [RequireHttps]
    public class ContactDetailsController : Controller
    {
        private MovieDataBaseEntitie db = new MovieDataBaseEntitie();

        // GET: ContactDetails
        public ActionResult Index()
        {
            return View(db.ContactDetails.ToList());
        }

        // GET: ContactDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // GET: ContactDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,State,PhoneNumber,Email,Password,Password2,EmailAddress,Game,AgeCheck,GameSystem")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                db.ContactDetails.Add(contactDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactDetail);
        }

        // GET: ContactDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,State,PhoneNumber,Email,Password,Password2,EmailAddress,Game,AgeCheck")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactDetail);
        }

        // GET: ContactDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            db.ContactDetails.Remove(contactDetail);
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
