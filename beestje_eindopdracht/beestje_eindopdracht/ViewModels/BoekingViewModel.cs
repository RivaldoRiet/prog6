using beestje_eindopdracht.Models;
using beestje_eindopdracht.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class BoekingViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Adres is niet geldig")]
        [MinLength(2)]
        [MaxLength(20)]
        public string contact_adres { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email adress niet valide")]
        [EmailAddress(ErrorMessage = "Email adress niet valide")]
        public string contact_email { get; set; }
        [Required(ErrorMessage = "Adres is niet valide")]
        [MinLength(2)]
        [MaxLength(20)]
        public string contact_naam { get; set; }
        [Display(Name = "Je telefoon nummer")]
        [Required(ErrorMessage = "Een telefoonnummer is verreist.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefoon nummer niet valide")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Telefoon nummer niet valide")]
        public string contact_telefoonnummer { get; set; }

        public DateTime dateTime { get; set; }
        public IEnumerable<Beestjes> UnavailableBeestjes { get; set; }
        public IEnumerable<Beestjes> AvailableBeestjes { get; set; }
        public IEnumerable<Beestjes> SelectedBeestjes { get; set; }

        public BoekingViewModel(Boeking boeking)
        {
            id = boeking.Id;
            contact_adres = boeking.contact_adres;
            contact_email = boeking.contact_email;
            contact_naam = boeking.contact_naam;
            contact_telefoonnummer = boeking.contact_telefoonnummer;
        }

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

        public Boeking ToNewInstanceModel()
        {
            var result = new List<Beestjes>();
            foreach (var beestje in this.SelectedBeestjes)
            {
                result.Add(beestje);
            }

            return new Boeking()
            {
                Id = this.id,
                Beestjes = result,
                datum = this.dateTime,
                contact_adres = this.contact_adres,
                contact_email = this.contact_email,
                contact_naam = this.contact_naam,
                contact_telefoonnummer = this.contact_telefoonnummer
        };
        }
    }
}