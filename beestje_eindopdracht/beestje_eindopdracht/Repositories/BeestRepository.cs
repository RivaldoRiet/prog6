using beestje_eindopdracht.Models;
using beestje_eindopdracht.Singleton;
using beestje_eindopdracht.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Repositories
{
    public class BeestRepository : IBeestRepository
    {
        private beestje_databaseEntities _context;
        private BeestType[] _beestTypes;
        private string[] _beestImages;

        public BeestRepository(beestje_databaseEntities context)
        {
            _context = context;
            _beestTypes = InitializeBeestTypes();
            _beestImages = InitializeBeestImages();
        }

        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="beestjesViewModel"></param>
        public void Create(BeestjesViewModel beestjesViewModel)
        {
            var beestType = _beestTypes.Where(r => r.Type.Equals(beestjesViewModel.BeestType)).FirstOrDefault();
            _context.Beestjes.Add(beestjesViewModel.ToNewInstanceModel(beestType));
            _context.SaveChanges();
        }

        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="beestjesViewModel"></param>
        public void Edit(BeestjesViewModel beestjesViewModel)
        {
            var beestType = _beestTypes.Where(r => r.Type.Equals(beestjesViewModel.BeestType)).FirstOrDefault();

            var beestje = this.getBeestById(beestjesViewModel.Id);
            beestje.Naam = beestjesViewModel.Name;
            beestje.Afbeelding = beestjesViewModel.SelectedImageUrl;
            beestje.Prijs = beestjesViewModel.Price;
            beestje.BeestType = beestType;
            _context.SaveChanges();
        }

        public IEnumerable<Beestjes> GetAvailableBeestjes()
        {
            var beestjeIsInDb = _context.Beestjes.OrderBy(t => t.Naam);
            if (beestjeIsInDb != null)
            {
                var result = new List<Beestjes>();

                foreach (var beestje in beestjeIsInDb)
                {
                    bool existsOnDate = false;
                    //als de current date niet bestaat dan kunnen we ook niet kijken welk beestje beschikbaar is
                    if (DataRepository.Instance.currDate != null)
                    {
                        //var boeking = _context.Boeking.Where(t => t.Id == beestje.Id).FirstOrDefault();
                        //neem de boeking waar het beestje bij hoort
                        foreach (Boeking boeking in beestje.Boeking)
                        {
                            if (DataRepository.Instance.currDate.CompareTo(boeking.datum) == 0)
                            {
                                //de datum is hetzelfde als dat van het beestje
                                existsOnDate = true;
                            }
                        }
                        if (!existsOnDate)
                        {
                            result.Add(beestje);
                        }
                    }
                }

                return result;
            }

            return null;
        }

        public IEnumerable<Beestjes> GetBeestByBoekingId(int boekingId)
        {
            var beestjeIsInDb = _context.Beestjes.Where(t => t.Boeking.FirstOrDefault().Id == boekingId);
            if (beestjeIsInDb != null)
            {
                var result = new List<Beestjes>();
                foreach (var beestje in beestjeIsInDb)
                {
                    result.Add(beestje);
                }
                return result;
            }

            return null;
        }

        public IEnumerable<Beestjes> GetBeestjes()
        {
            var beestjes = _context.Beestjes.OrderBy(t => t.Naam);
            List<Beestjes> result = new List<Beestjes>();

            foreach (var beestje in beestjes)
            {
                result.Add(beestje);
            }

            return result;
        }

        public Beestjes getBeestById(int id)
        {
            var beestjes = _context.Beestjes.OrderBy(t => t.Naam);
            List<Beestjes> result = new List<Beestjes>();

            foreach (var beestje in beestjes)
            {
                if (beestje.Id == id)
                {
                    return beestje;
                }

            }
            return null;
        }

        public BeestType[] GetBeestTypes()
        {
            return _beestTypes;
        }

        public string[] GetBeestImages()
        {
            return _beestImages;
        }

        private BeestType[] InitializeBeestTypes()
        {
            BeestType[] result = new BeestType[4];

            result[0] = new BeestType() { id = 1, Type = "Jungle" };
            result[1] = new BeestType() { id = 2, Type = "Boerderij" };
            result[2] = new BeestType() { id = 3, Type = "Sneeuw" };
            result[3] = new BeestType() { id = 4, Type = "Woestijn" };

            return result;
        }

        private string[] InitializeBeestImages()
        {
            string[] result = new string[16];

            for (int x = 1; x <= result.Length; x++)
            {
                result[x - 1] = "/Content/Images/Beestjes/beestje" + x + ".png";
            }

            return result;
        }
    }
}