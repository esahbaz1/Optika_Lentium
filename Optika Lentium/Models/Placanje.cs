using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Optika_Lentium.Models
{
    public class Placanje
    {
        public Korisnik korisnik { get; set; }  
        public NacinPlacanja nacinPlacanja { get; set; }    
        public int Id { get; set; } 
        public Popust Popust { get; set; }  
        public Boolean bankovniRacun {  get; set; } 
        public double iznosPlacanja { get; set; }   

        public Placanje() { }   


    }
}
