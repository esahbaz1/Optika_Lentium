using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace Optika_Lentium.Models
{
    public class Placanje
    {
        [Key]
        public int Id { get; set; } 
        public Korisnik korisnik { get; set; }  
        public NacinPlacanja nacinPlacanja { get; set; }    
        
        public Popust Popust { get; set; }  
        public Boolean bankovniRacun {  get; set; } 
        public double iznosPlacanja { get; set; }

        [ForeignKey("ValidacijaProizvoda")]
        public int valProizvodId {get; set;}
        public Placanje() { }   


    }
}
