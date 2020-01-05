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

        public void Create(BoekingViewModel boekingViewModel, IBeestRepository beestRepository)
        {
            Boeking boeking = new Boeking();
            boeking.Id = boekingViewModel.id;
            boeking.contact_naam = boekingViewModel.contact_naam;
            boeking.contact_email = boekingViewModel.contact_email;
            boeking.contact_adres = boekingViewModel.contact_adres;
            boeking.contact_telefoonnummer = boekingViewModel.contact_telefoonnummer;
            boeking.datum = boekingViewModel.dateTime;
            foreach (var beest in DataRepository.Instance.beestjes)
            {
                Beestjes b = beestRepository.getBeestById(beest.Id);
                boeking.Beestjes.Add(b);
            }
            _context.Boeking.Add(boeking);
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
            var boekingen = _context.Beestjes.SelectMany(b => b.Boeking);
            var result = new List<Boeking>();

            foreach (var boeking in boekingen)
            {
                foreach (var beestje in boeking.Beestjes)
                {
                    if (beestje.Id == beestID) {
                        result.Add(boeking);
                    }
                }
                
            }
            return result;
        }
    }
}