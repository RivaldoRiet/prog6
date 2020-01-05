using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using beestje_eindopdracht.Models;
using beestje_eindopdracht.ViewModels;
using beestje_eindopdracht.Repositories;


namespace beestje_eindopdracht.Controllers
{
    public class BeestjesController : Controller
    {
        private beestje_databaseEntities db = new beestje_databaseEntities();
        private IBeestRepository _beestRepository;
        private IBoekingRepository _boekingRepository;
        public BeestjesController(IBeestRepository beestRepository, IBoekingRepository boekingRepository)
        {
            _beestRepository = beestRepository;
            _boekingRepository = boekingRepository;
        }
        // GET: Beestjes
        public ActionResult Index()
        {
            var beestjes = db.Beestjes.Include(b => b.BeestType);
            return View(beestjes.ToList());
        }

        // GET: Beestjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beestjes beestjes = db.Beestjes.Find(id);
            if (beestjes == null)
            {
                return HttpNotFound();
            }
            return View(beestjes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BeestjesViewModel() { BeestTypes = _beestRepository.GetBeestTypes().Select(r => r.Type).ToArray(), BeestImages = _beestRepository.GetBeestImages() });
        }

        [HttpPost]
        public ActionResult Create(BeestjesViewModel beestjesViewModel)
        {
            if (!ModelState.IsValid)
            {
                beestjesViewModel.BeestImages = _beestRepository.GetBeestImages();
                return View(beestjesViewModel);
            }

            _beestRepository.Create(beestjesViewModel);

            return RedirectToAction("Index");
        }

        // GET: Beestjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beestjes beestjes = db.Beestjes.Find(id);
            if (beestjes == null)
            {
                return HttpNotFound();
            }
            ViewBag.BeestType_id = new SelectList(db.BeestType, "id", "Type", beestjes.BeestType_id);
            return View(beestjes);
        }

        // POST: Beestjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BeestType_id,Naam,Prijs,Afbeelding")] Beestjes beestjes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beestjes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeestType_id = new SelectList(db.BeestType, "id", "Type", beestjes.BeestType_id);
            return View(beestjes);
        }

        // GET: Beestjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beestjes beestjes = db.Beestjes.Find(id);
            if (beestjes == null)
            {
                return HttpNotFound();
            }
            return View(beestjes);
        }

        // POST: Beestjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beestjes beestjes = db.Beestjes.Find(id);
            db.Beestjes.Remove(beestjes);
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