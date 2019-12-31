using beestje_eindopdracht.Models;
using beestje_eindopdracht.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Repositories
{
    public class BeestRepository : IBeestRepository
    {
        private beestje_databaseEntities _context;
        public BeestRepository(beestje_databaseEntities context)
        {
            _context = context;
        }
        public IEnumerable<Beestjes> GetAvailableBeestjes()
        {
            var beestjeIsInDb = _context.Beestjes.Where(t => t.Boeking_id == null);
            if (beestjeIsInDb != null)
            {
                var result = new List<Beestjes>();
                
                    foreach (var beestje in beestjeIsInDb)
                    {
                    //als de current date niet bestaat dan kunnen we ook niet kijken welk beestje beschikbaar is
                    if (DataRepository.Instance.currDate != null) {
                        var boeking = _context.Boeking.Where(t => t.Id == beestje.Id).FirstOrDefault();
                        //neem de boeking waar het beestje bij hoort
                        if (boeking != null) {
                             if (DataRepository.Instance.currDate.CompareTo(boeking.datum) == 0) {
                                 //de datum is hetzelfde als dat van het beestje
                                 continue;
                             }
                             else
                             {
                                 //de datum is niet hetzelfde
                                 result.Add(beestje);
                             }
                        }
                        else
                        {
                            //beestje heeft geen boeking
                            result.Add(beestje);
                        }
                    }
                }

                return result;
            }

            return null;
        }

        public IEnumerable<Beestjes> GetBeestByBoekingId(int boekingId)
        {
            var beestjeIsInDb = _context.Beestjes.Where(t => t.Boeking_id == boekingId);
            if (beestjeIsInDb != null)
            {
                var result = new List<Beestjes>();
                foreach (var beestje in beestjeIsInDb)
                {
                    result.Add(beestje);
                }
                return result;
            }

            return null;
        }

        public IEnumerable<Beestjes> GetBeestjes()
        {
            var beestjes = _context.Beestjes.OrderBy(t => t.Naam);
            List<Beestjes> result = new List<Beestjes>();

            foreach (var beestje in beestjes)
            {
                result.Add(beestje);
            }

            return result;
        }

        public Beestjes getBeestById(int id)
        {
            var beestjes = _context.Beestjes.OrderBy(t => t.Naam);
            List<Beestjes> result = new List<Beestjes>();

            foreach (var beestje in beestjes)
            {
                if (beestje.Id == id)
                {
                    return beestje;
                }
                
            }
            return null;
        }
    }
}