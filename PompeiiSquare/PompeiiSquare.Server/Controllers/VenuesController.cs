using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PompeiiSquare.Data;
using PompeiiSquare.Models;
using PompeiiSquare.Data.UnitOfWork;

namespace PompeiiSquare.Server.Controllers
{
    public class VenuesController : BaseController
    {
        private PompeiiSquareDbContext db = new PompeiiSquareDbContext();
        // TODO: use data for controller!!!

        public VenuesController(IPompeiiSquareData data)
            : base(data)
        {

        }

        // GET: Venues
        public ActionResult Index()
        {
            //return View(db.Venues.ToList());
            return View(this.Data.Venues.All());
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venue = Data.Venues.Find(id); // db.Venues.Find(id);

            if (venue == null)
            {
                return HttpNotFound();
            }

            return View(venue);
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Contact,Location,PriceTier,Description,CreatedAt,Likes")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                this.Data.Venues.Add(venue);
                this.Data.SaveChanges();
                //db.Venues.Add(venue);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venue);
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venue = this.Data.Venues.Find(id); //db.Venues.Find(id);

            if (venue == null)
            {
                return HttpNotFound();
            }

            return View(venue);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Contact,Location,PriceTier,Description,CreatedAt,Likes")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venue = this.Data.Venues.Find(id); //db.Venues.Find(id);

            if (venue == null)
            {
                return HttpNotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = this.Data.Venues.Find(id); //db.Venues.Find(id);
            this.Data.Venues.Remove(venue);
            this.Data.SaveChanges();
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
