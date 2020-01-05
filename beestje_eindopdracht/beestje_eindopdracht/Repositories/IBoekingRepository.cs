using beestje_eindopdracht.Models;
using beestje_eindopdracht.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beestje_eindopdracht.Repositories
{
    public interface IBoekingRepository
    {
        void Create(BoekingViewModel boekingViewModel, IBeestRepository beestRepository);
        bool Delete(int id);
        IEnumerable<Boeking> GetBoekingenByBeestId(int? beestID);
        IEnumerable<Boeking> GetBoekingen();
        Boeking getBoekingById(int? id);
    }
}
