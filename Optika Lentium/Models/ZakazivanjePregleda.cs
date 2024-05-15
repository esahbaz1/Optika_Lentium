using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optika_Lentium.Models
{
    public class ZakazivanjePregleda
    {
        public int pregledId {  get; set; } 
        public Korisnik korisnik { get; set; }  
        public DateTime datum { get; set; } 
        public string potvrdaZakazivanja {  get; set; } 
        public ZakazivanjePregleda() { }    

    }
}