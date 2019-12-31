using beestje_eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beestje_eindopdracht.Singleton
{
    public class DataRepository
    {
        private static readonly DataRepository _instance = new DataRepository();
        public static DataRepository Instance => _instance;
        public DateTime currDate { get; set; }
        public IEnumerable<Beestjes> beestjes { get; set; }
        static DataRepository()
        {
        }

        private DataRepository()
        {
    
        }

    }
}