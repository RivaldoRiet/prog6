using beestje_eindopdracht.Models;
using beestje_eindopdracht.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Repositories
{
    public class AccessoiresRepository : IAccessoiresRepository
    {
        private beestje_databaseEntities _context;
        private Beestjes[] _beestjes;
        private string[] _accessoireImages;

        public AccessoiresRepository(beestje_databaseEntities context)
        {
            _context = context;
            _beestjes = InitializeBeesten();
            _accessoireImages = InitializeBeestImages();
        }

        public IEnumerable<Accessoires> GetAccessoires(int? beestID)
        {
            if (beestID == null)
            {
                return null;
            }
            IEnumerable<Accessoires> accessoires = _context.Accessoires.Where(a => a.Beestje_id == beestID);
            return accessoires;
        }

        public Accessoires GetAccessoiresById(int? accessoiresID)
        {
            return _context.Accessoires.Where(a => a.Id == accessoiresID).FirstOrDefault();
        }

        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="AccessoiresViewModel"></param>
        public void Create(AccessoiresViewModel accessoiresViewModel)
        {
            var beest = _beestjes.Where(r => r.Naam.Equals(accessoiresViewModel.Beest)).FirstOrDefault();
            _context.Accessoires.Add(accessoiresViewModel.ToNewInstanceModel(beest));
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


        //deze nog omschrijven
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