using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using beestje_eindopdracht.Models;
using beestje_eindopdracht.Repositories;
using beestje_eindopdracht.Singleton;
using beestje_eindopdracht.ViewModels;

namespace beestje_eindopdracht.Controllers
{
    public class BoekingController : Controller
    {
        private IBeestRepository beestRepository;
        private IBoekingRepository boekingRepository;
        private IAccessoiresRepository accessoiresRepository;
        public BoekingController(IBeestRepository beestRepository, IBoekingRepository boekingRepository, IAccessoiresRepository accessoiresRepository)
        {
            this.beestRepository = beestRepository;
            this.boekingRepository = boekingRepository;
            this.accessoiresRepository = accessoiresRepository;
        }

        // GET: Boeking
        public ActionResult Index()
        {
            return View(boekingRepository.GetBoekingen());
        }

        // GET: Boeking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Boeking boeking = boekingRepository.getBoekingById(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        public ActionResult BoekingOverzicht()
        {
            var availableBeestjes = beestRepository.GetAvailableBeestjes();
            var allBeestjes = beestRepository.GetBeestjes();
            var unavailableBeestjes = allBeestjes.Except(availableBeestjes);
            BoekingViewModel boekingViewModel = new BoekingViewModel(unavailableBeestjes, availableBeestjes, DataRepository.Instance.beestjes, DataRepository.Instance.currDate, DataRepository.Instance.accessoires);
            boekingViewModel.contact_email = DataRepository.Instance.boekingViewModel.contact_email;
            boekingViewModel.contact_adres = DataRepository.Instance.boekingViewModel.contact_adres;
            boekingViewModel.contact_naam = DataRepository.Instance.boekingViewModel.contact_naam;
            boekingViewModel.contact_telefoonnummer = DataRepository.Instance.boekingViewModel.contact_telefoonnummer;

            return View(boekingViewModel);
        }

        [HttpPost]
        public ActionResult BoekingOverzicht(int? id)
        {
            DataRepository.Instance.boekingViewModel.beestjes = DataRepository.Instance.beestjes.ToList();
            DataRepository.Instance.boekingViewModel.dateTime = DataRepository.Instance.currDate;
            boekingRepository.Create(DataRepository.Instance.boekingViewModel, beestRepository);
            return RedirectToAction("Index");
        }

        public ActionResult AccessoiresSelect()
        {
            List<Accessoires> selectableAccesoires = new List<Accessoires>();
            if (DataRepository.Instance.beestjes != null) {
                foreach (var beest in DataRepository.Instance.beestjes)
                {
                    foreach (var a in accessoiresRepository.GetAccessoires(beest.Id))
                    {
                        selectableAccesoires.Add(a);
                    }
                }
                return View(selectableAccesoires);
            }

            return View();
            
        }

        [HttpPost]
        public ActionResult AccessoiresSelect(int? id)
        {
            string jsonData = Request.Form[0];
            var intArr = jsonData.Split(',').ToList();
            List<Accessoires> accessoires = new List<Accessoires>();
            foreach (var item in intArr)
            {
                int accessoiresID = Int32.Parse(item);
                accessoires.Add(accessoiresRepository.GetAccessoiresById(accessoiresID));
            }
            DataRepository.Instance.accessoires = null;
            DataRepository.Instance.accessoires = accessoires;
            return RedirectToAction("Create");
        }

        public ActionResult BoekingDatumSelect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BoekingDatumSelect(int? id)
        {
            string jsonData = Request.Form[0];
            var date = DateTime.Parse(jsonData);
            DataRepository.Instance.currDate = date;
            return RedirectToAction("BeestjeSelect");
        }

        public ActionResult BeestjeSelect()
        {
            var availableBeestjes = beestRepository.GetAvailableBeestjes();
            var allBeestjes = beestRepository.GetBeestjes();
            var unavailableBeestjes = allBeestjes.Except(availableBeestjes);
            BoekingViewModel boekingViewModel = new BoekingViewModel(unavailableBeestjes, availableBeestjes, DataRepository.Instance.beestjes, DataRepository.Instance.currDate, DataRepository.Instance.accessoires);
            return View(boekingViewModel);
        }

        [HttpPost]
        public ActionResult BeestjeSelect(int? id)
        {
            string jsonData = Request.Form[0];
            var intArr = jsonData.Split(',').ToList();
            List<Beestjes> beestjes = new List<Beestjes>();
            foreach (var item in intArr)
            {
                int beestID = Int32.Parse(item);
                beestjes.Add(beestRepository.getBeestById(beestID));
            }
            DataRepository.Instance.beestjes = null;
            DataRepository.Instance.beestjes = beestjes;
            return RedirectToAction("AccessoiresSelect");
        }

        // GET: Boeking/Create
        public ActionResult Create()
        {
            if (DataRepository.Instance.currDate == null || DataRepository.Instance.currDate != null && DataRepository.Instance.currDate.Year < 2020)
            {
                return RedirectToAction("BoekingDatumSelect");
            }
            var availableBeestjes = beestRepository.GetAvailableBeestjes();
            var allBeestjes = beestRepository.GetBeestjes();
            var unavailableBeestjes = allBeestjes.Except(availableBeestjes);
            BoekingViewModel boekingViewModel = new BoekingViewModel(unavailableBeestjes, availableBeestjes, DataRepository.Instance.beestjes, DataRepository.Instance.currDate, DataRepository.Instance.accessoires);

            return View(boekingViewModel);
        }

        // POST: Boeking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoekingViewModel boekingViewModel)
        {
            if (ModelState.IsValid)
            {
                DataRepository.Instance.boekingViewModel = boekingViewModel;
                return RedirectToAction("BoekingOverzicht");
            }

            return View();
        }

        // GET: Boeking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boeking boeking = boekingRepository.getBoekingById(id);
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
            if (boekingRepository.Delete(id)) {
                return RedirectToAction("Index");
            }
            else
            {
                return Json("Failed to delete");
            }
        }
    }
}
