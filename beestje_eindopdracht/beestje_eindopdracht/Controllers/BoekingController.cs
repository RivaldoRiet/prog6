using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using beestje_eindopdracht.Models;
using beestje_eindopdracht.Repositories;

namespace beestje_eindopdracht.Controllers
{
    public class BoekingController : Controller
    {
        private beestje_databaseEntities db = new beestje_databaseEntities();
        private BeestRepository beestRepository;
        private System.DateTime date;
        // GET: Boeking
        public ActionResult Index()
        {
            return View(db.Boeking.ToList());
        }

        // GET: Boeking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boeking boeking = db.Boeking.Find(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        // GET: Boeking/Create
        public ActionResult Create()
        {
            beestRepository = new BeestRepository(db);
            var availableBeestjes = beestRepository.GetAvailableBeestjes();
            return View();
        }

        [HttpPost]
        public ActionResult setDate(string date)
        {
            if (date.Equals(""))
            {
                return View();
            }

            this.date = DateTime.Parse(date);

            return View();
        }

        // POST: Boeking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,datum,contact_naam,contact_adres,contact_email,contact_telefoonnummer")] Boeking boeking)
        {
            if (ModelState.IsValid)
            {
                db.Boeking.Add(boeking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boeking);
        }

        // GET: Boeking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boeking boeking = db.Boeking.Find(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        // POST: Boeking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,datum,contact_naam,contact_adres,contact_email,contact_telefoonnummer")] Boeking boeking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boeking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boeking);
        }

        // GET: Boeking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boeking boeking = db.Boeking.Find(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        // POST: Boeking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boeking boeking = db.Boeking.Find(id);
            db.Boeking.Remove(boeking);
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
