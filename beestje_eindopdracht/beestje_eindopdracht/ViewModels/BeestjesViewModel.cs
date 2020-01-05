﻿using beestje_eindopdracht.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.ViewModels
{
    public class BeestjesViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is not valid")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Prijs is niet goed ingevuld")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Beest type is required")]
        public BeestType BeestType { get; set; }

        [Required(ErrorMessage = "Beest image is required")]
        public string SelectedImageUrl { get; set; }

        // Only used for UI
        public int AmountOfBedTaken { get; set; }
        public string[] BeestTypes { get; set; }
        public string[] BeestImages { get; set; }
        public ICollection<Boeking> beest_boeking { get; set; }
        public ICollection<Accessoires> beest_accessoires { get; set; }
        public int beest_type_id { get; set; }
        public BeestjesViewModel()
        {

        }

        public BeestjesViewModel(Beestjes beest)
        {
            Id = beest.Id;
            Name = beest.Naam;
            Price = beest.Prijs;
            BeestType = beest.BeestType;
            SelectedImageUrl = beest.Afbeelding;
            beest_boeking = beest.Boeking;
            beest_accessoires = beest.Accessoires;
            beest_type_id = beest.BeestType_id;
        }

        /// <summary>
        /// Will be used only in a repository class(during the creation of a room)
        /// </summary>
        /// <returns></returns>
        public Beestjes ToNewInstanceModel(BeestType beestType)
        {
            if (Name == null || SelectedImageUrl == null)
            {
                return null;
            }

            return new Beestjes()
            {
                Id = this.Id,
                Naam = this.Name,
                Prijs = this.Price,
                Afbeelding = this.SelectedImageUrl,
                BeestType = this.BeestType,
                Boeking = this.beest_boeking,
                Accessoires = this.beest_accessoires,
                BeestType_id = this.beest_type_id
            };
        }
        public Beestjes ToNewInstanceModel()
        {
            if (Name == null || SelectedImageUrl == null)
            {
                return null;
            }

            return new Beestjes()
            {
                Id = this.Id,
                Naam = this.Name,
                Prijs = this.Price,
                Afbeelding = this.SelectedImageUrl,
                BeestType = this.BeestType,
                Boeking = this.beest_boeking,
                Accessoires = this.beest_accessoires,
                BeestType_id = this.beest_type_id
            };
        }
    }
}