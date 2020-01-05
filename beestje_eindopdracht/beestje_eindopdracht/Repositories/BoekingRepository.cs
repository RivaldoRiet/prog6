using beestje_eindopdracht.Models;
using beestje_eindopdracht.Singleton;
using beestje_eindopdracht.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Repositories
{
    public class BoekingRepository : IBoekingRepository
    {
        private beestje_databaseEntities _context;
        public BoekingRepository(beestje_databaseEntities context)
        {
            _context = context;
        }

        public void Create(BoekingViewModel boekingViewModel)
        {
            _context.Boeking.Add(boekingViewModel.ToNewInstanceModel());
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var boeking = _context.Boeking.Where(r => r.Id == id).FirstOrDefault();
            if (boeking != null)
            {
                _context.Boeking.Remove(boeking);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
        public Boeking getBoekingById(int? id)
        {
            return _context.Boeking.Where(b => b.Id == id).FirstOrDefault();
        }
        public IEnumerable<Boeking> GetBoekingen()
        {
            return _context.Boeking.ToList();
        }

        public IEnumerable<Boeking> GetBoekingenByBeestId(int? beestID)
        {
            if (beestID == null)
            {
                return null;
            }
            //alle boekingen ophalen waarbij het beestje voorkomt
            var boekingen = _context.Boeking.Where(t => t.Beestjes.Count > 0);
            var result = new List<Boeking>();

            foreach (var boeking in boekingen)
            {
                if (boeking.Id == beestID)
                {
                    result.Add(boeking);
                }
            }
            return result;
        }
    }
}