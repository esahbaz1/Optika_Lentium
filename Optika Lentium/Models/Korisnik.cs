using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Korisnik
    {
        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }
        public string email { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string sifra { get; set; }
        
        public Korisnik() { }   
       
    }
}
