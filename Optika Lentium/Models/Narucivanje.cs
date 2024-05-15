using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Narucivanje
    {
        public int narucivanjeID { get; set; }
        public double ukupniRacunZaPlacanje {  get; set; }  
        public Korisnik korisnik { get; set; }  

        public Placanje placanje { get; set; }  

        public int zaliha {  get; set; }    

        public Narucivanje() { }


    }
}

