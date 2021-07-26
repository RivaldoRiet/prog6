using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beestje_eindopdracht.Repositories
{
    public interface IAccessoiresRepository
    {
        IEnumerable<Accessoires> GetAccessoires(int? beestID);
        Accessoires GetAccessoiresById(int? accessoiresID);
    }
}
