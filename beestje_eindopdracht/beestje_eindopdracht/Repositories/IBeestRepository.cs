using beestje_eindopdracht.Models;
using beestje_eindopdracht.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beestje_eindopdracht.Repositories
{
    public interface IBeestRepository
    {
        IEnumerable<Beestjes> GetBeestByBoekingId(int boekingId);
        IEnumerable<Beestjes> GetAvailableBeestjes();
        IEnumerable<Beestjes> GetBeestjes();
        Beestjes getBeestById(int id);
        void Create(BeestjesViewModel beestViewModel);
        void Edit(BeestjesViewModel beestViewModel);
        BeestType[] GetBeestTypes();
        string[] GetBeestImages();
    }
}