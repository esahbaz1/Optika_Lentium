using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class Narucivanje
    {
        [Key]
        public int narucivanjeId { get; set; }
        public double ukupniRacunZaPlacanje {  get; set; }  
        public Korisnik korisnik { get; set; }

        [ForeignKey("Proizvod")]
        public int proizvodId { get; set; } 
        
        public int zaliha {  get; set; }    

        public Narucivanje() { }


    }
}

