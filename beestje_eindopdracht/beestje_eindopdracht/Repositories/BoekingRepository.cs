using beestje_eindopdracht.Models;
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