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
        public BoekingController(IBeestRepository beestRepository, IBoekingRepository boekingRepository)
        {
            this.beestRepository = beestRepository;
            this.boekingRepository = boekingRepository;
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
            BoekingViewModel boekingViewModel = new BoekingViewModel(unavailableBeestjes, availableBeestjes, DataRepository.Instance.beestjes, DataRepository.Instance.currDate);
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
            return RedirectToAction("Create");
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
            BoekingViewModel boekingViewModel = new BoekingViewModel(unavailableBeestjes, availableBeestjes, DataRepository.Instance.beestjes, DataRepository.Instance.currDate);

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
                boekingViewModel.SelectedBeestjes = DataRepository.Instance.beestjes.ToList();
                boekingViewModel.dateTime = DataRepository.Instance.currDate;
                boekingRepository.Create(boekingViewModel);
                return RedirectToAction("Index");
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
