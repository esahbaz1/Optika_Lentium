using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class PregledKorisnik
    {
        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }
        public int pregledID { get; set; }
        
        public PregledKorisnik() { }   
    }
}
