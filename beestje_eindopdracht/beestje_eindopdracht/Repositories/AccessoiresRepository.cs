using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Repositories
{
    public class AccessoiresRepository : IAccessoiresRepository
    {
        private beestje_databaseEntities _context;
        public AccessoiresRepository(beestje_databaseEntities context)
        {
            _context = context;
        }
        public IEnumerable<Accessoires> GetAccessoires(int? beestID)
        {
            if (beestID == null)
            {
                return null;
            }
            IEnumerable<Accessoires> accessoires = _context.Accessoires.Where(a => a.Beestje_id == beestID);
            return accessoires;
        }

        public Accessoires GetAccessoiresById(int? accessoiresID)
        {
            return _context.Accessoires.Where(a => a.Id == accessoiresID).FirstOrDefault();
        }
    }
}