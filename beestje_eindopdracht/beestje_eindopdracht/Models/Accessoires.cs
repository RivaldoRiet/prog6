//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace beestje_eindopdracht.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accessoires
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string Afbeelding { get; set; }
        public int Beestje_id { get; set; }
    
        public virtual Beestjes Beestjes { get; set; }
    }
}
