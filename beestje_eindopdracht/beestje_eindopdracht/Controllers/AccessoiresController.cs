using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using beestje_eindopdracht.Models;

namespace beestje_eindopdracht.Controllers
{
    public class AccessoiresController : Controller
    {
        private beestje_databaseEntities db = new beestje_databaseEntities();

        // GET: Accessoires
        public ActionResult Index()
        {
            var accessoires = db.Accessoires.Include(a => a.Beestjes);
            return View(accessoires.ToList());
        }

        // GET: Accessoires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoires accessoires = db.Accessoires.Find(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            return View(accessoires);
        }

        // GET: Accessoires/Create
        public ActionResult Create()
        {
            ViewBag.Beestje_id = new SelectList(db.Beestjes, "Id", "Naam");
            return View();
        }

        // POST: Accessoires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Prijs,Afbeelding,Beestje_id")] Accessoires accessoires)
        {
            if (ModelState.IsValid)
            {
                db.Accessoires.Add(accessoires);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Beestje_id = new SelectList(db.Beestjes, "Id", "Naam", accessoires.Beestje_id);
            return View(accessoires);
        }

        // GET: Accessoires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoires accessoires = db.Accessoires.Find(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            ViewBag.Beestje_id = new SelectList(db.Beestjes, "Id", "Naam", accessoires.Beestje_id);
            return View(accessoires);
        }

        // POST: Accessoires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Prijs,Afbeelding,Beestje_id")] Accessoires accessoires)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoires).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Beestje_id = new SelectList(db.Beestjes, "Id", "Naam", accessoires.Beestje_id);
            return View(accessoires);
        }

        // GET: Accessoires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoires accessoires = db.Accessoires.Find(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            return View(accessoires);
        }

        // POST: Accessoires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessoires accessoires = db.Accessoires.Find(id);
            db.Accessoires.Remove(accessoires);
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
