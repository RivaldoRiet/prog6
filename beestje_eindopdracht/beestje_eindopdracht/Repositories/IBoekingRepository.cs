using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beestje_eindopdracht.Repositories
{
    interface IBoekingRepository
    {
        IEnumerable<Boeking> GetBoekingenByBeestId(int? beestID);
    }
}
