using beestje_eindopdracht.Models;
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
                    result.Add(beestje);
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
    }
}