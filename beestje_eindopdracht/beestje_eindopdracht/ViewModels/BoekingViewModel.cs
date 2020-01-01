using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class BoekingViewModel
    {
        public IEnumerable<Beestjes> UnavailableBeestjes { get; set; }
        public IEnumerable<Beestjes> AvailableBeestjes { get; set; }
        public IEnumerable<Beestjes> SelectedBeestjes { get; set; }

        public BoekingViewModel() { }

        public BoekingViewModel(IEnumerable<Beestjes> unavailableBeestjes,
                        IEnumerable<Beestjes> availableBeestjes, IEnumerable<Beestjes> selectedBeestjes)
        {
            UnavailableBeestjes = unavailableBeestjes;
            AvailableBeestjes = availableBeestjes;
            SelectedBeestjes = selectedBeestjes;
        }
    }
}