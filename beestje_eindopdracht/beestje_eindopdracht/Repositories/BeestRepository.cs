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
        private string[] _beestImages;

        public BeestRepository(beestje_databaseEntities context)
        {
            _context = context;
            _beestImages = InitializeBeestImages();
        }

        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="beestjesViewModel"></param>
        public void Create(BeestjesViewModel beestjesViewModel)
        {
            _context.Beestjes.Add(beestjesViewModel.ToNewInstanceModel());
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
                    if (DataRepository.Instance.currDate != null) {
                        //var boeking = _context.Boeking.Where(t => t.Id == beestje.Id).FirstOrDefault();
                        //neem de boeking waar het beestje bij hoort
                            foreach (Boeking boeking in beestje.Boeking) {
                                if (DataRepository.Instance.currDate.CompareTo(boeking.datum) == 0) {
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

        public string[] GetBeestImages()
        {
            return _beestImages;
        }

        private string[] InitializeBeestImages()
        {
            string[] result = new string[17];

            for (int x = 0; x < result.Length; x++)
            {
                result[x] = "/Content/Images/Beestjes/beestje" + x + ".png";
            }

            return result;
        }
    }
}