using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beestje_eindopdracht.Repositories
{
    interface IBeestRepository
    {
        IEnumerable<Beestjes> GetBeestByBoekingId(int boekingId);
        IEnumerable<Beestjes> GetAvailableBeestjes();
        IEnumerable<Beestjes> GetBeestjes();
    }
}
