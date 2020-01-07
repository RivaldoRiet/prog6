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
        [Display(Name = "Contact adres:")]
        [Required(ErrorMessage = "Adres is niet geldig")]
        [MinLength(2)]
        [MaxLength(20)]
        public string contact_adres { get; set; }
        [Display(Name = "Emailaddress")]
        [EmailAddress(ErrorMessage = "Email adress is niet valide")]
        public string contact_email { get; set; }
        [Display(Name = "Contact naam:")]
        [Required(ErrorMessage = "Contact naam is niet valide")]
        [MinLength(2)]
        [MaxLength(20)]
        public string contact_naam { get; set; }
        [Display(Name = "Telefoonnummer:")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefoon nummer niet valide")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Telefoon nummer niet valide")]
        public string contact_telefoonnummer { get; set; }

        public DateTime dateTime { get; set; }
        public ICollection<Beestjes> beestjes { get; set; }
        public IEnumerable<Beestjes> UnavailableBeestjes { get; set; }
        public IEnumerable<Beestjes> AvailableBeestjes { get; set; }
        public IEnumerable<Beestjes> SelectedBeestjes { get; set; }
        public IEnumerable<Accessoires> SelectedAccessoires { get; set; }

        public BoekingViewModel(Boeking boeking)
        {
            id = boeking.Id;
            beestjes = boeking.Beestjes;
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
            SelectedAccessoires = new List<Accessoires>();
        }

        public BoekingViewModel(IEnumerable<Beestjes> unavailableBeestjes,
                        IEnumerable<Beestjes> availableBeestjes, IEnumerable<Beestjes> selectedBeestjes, DateTime date, IEnumerable<Accessoires> selectedAccessoires)
        {
            UnavailableBeestjes = unavailableBeestjes;
            AvailableBeestjes = availableBeestjes;
            SelectedBeestjes = selectedBeestjes;
            dateTime = date;
            SelectedAccessoires = selectedAccessoires;
        }
    }
}