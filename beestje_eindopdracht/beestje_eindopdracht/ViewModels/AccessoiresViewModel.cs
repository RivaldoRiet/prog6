using beestje_eindopdracht.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class AccessoiresViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is not valid")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Accessoire is niet goed ingevuld")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Beest type is required")]
        public string Beest { get; set; }

        [Required(ErrorMessage = "Accessoire image is required")]
        public string SelectedImageUrl { get; set; }

        // Only used for UI
        public string[] Beestjes { get; set; }
        public string[] AccessoiresImages { get; set; }

        public AccessoiresViewModel()
        {

        }

        public AccessoiresViewModel(Accessoires accessoire)
        {
            Id = accessoire.Id;
            Name = accessoire.Naam;
            Price = accessoire.Prijs;
            SelectedImageUrl = accessoire.Afbeelding;
            Beest = accessoire.Beestjes.Naam;
        }

        /// <summary>
        /// Will be used only in a repository class(during the creation of a room)
        /// </summary>
        /// <returns></returns>
        public Accessoires ToNewInstanceModel(Beestjes beestje)
        {
            if (Name == null || SelectedImageUrl == null)
            {
                return null;
            }

            return new Accessoires()
            {
                Id = this.Id,
                Naam = this.Name,
                Prijs = this.Price,
                Afbeelding = this.SelectedImageUrl,
                Beestjes = beestje,
            };
        }
    }
}