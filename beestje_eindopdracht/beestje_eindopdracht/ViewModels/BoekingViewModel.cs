using beestje_eindopdracht.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class BoekingViewModel
    {
        public DateTime dateTime { get; set; }
        public IEnumerable<Beestjes> UnavailableBeestjes { get; set; }
        public IEnumerable<Beestjes> AvailableBeestjes { get; set; }
        public IEnumerable<Beestjes> SelectedBeestjes { get; set; }

        public BoekingViewModel() {
            dateTime = new DateTime();
            UnavailableBeestjes = new List<Beestjes>();
            AvailableBeestjes = new List<Beestjes>();
            SelectedBeestjes = new List<Beestjes>();
        }

        public BoekingViewModel(IEnumerable<Beestjes> unavailableBeestjes,
                        IEnumerable<Beestjes> availableBeestjes, IEnumerable<Beestjes> selectedBeestjes, DateTime date)
        {
            UnavailableBeestjes = unavailableBeestjes;
            AvailableBeestjes = availableBeestjes;
            SelectedBeestjes = selectedBeestjes;
            dateTime = date;
        }
    }
}