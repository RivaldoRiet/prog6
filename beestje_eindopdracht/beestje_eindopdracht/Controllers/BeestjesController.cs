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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return RedirectToAction("Index", "Beestjes");
            }

            var beestViewModel = _beestRepository.getBeestById((int)id);
            if (beestViewModel != null)
            {
              
                BeestjesViewModel beestjesViewModel = new BeestjesViewModel(beestViewModel);

                beestjesViewModel.BeestTypes = _beestRepository.GetBeestTypes().Select(r => r.Type).ToArray();
                beestjesViewModel.BeestImages = _beestRepository.GetBeestImages();

                return View(beestjesViewModel);
            }

            return RedirectToAction("Index", "Beest");
        }

        [HttpPost]
        public ActionResult Edit(BeestjesViewModel beestjesViewModel)
        {
            if (!ModelState.IsValid)
            {
                beestjesViewModel.BeestImages = _beestRepository.GetBeestImages();
                return View(beestjesViewModel);
            }

            _beestRepository.Edit(beestjesViewModel);

            return RedirectToAction("Index");
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
            var boekingen = _boekingRepository.GetBoekingenByBeestId(id);

            var tuple = new Tuple<Beestjes, IEnumerable<Boeking>>(beestjes, boekingen);
            return View(tuple);
        }
    }
}