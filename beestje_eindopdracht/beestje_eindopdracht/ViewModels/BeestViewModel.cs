using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class BeestViewModel
    {
        public IEnumerable<Boeking> boekingen { get; set; }
        public BeestViewModel(IEnumerable<Boeking> boekingen)
        {
            this.boekingen = boekingen;
        }
    }
}