using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class LokacijaKorisnik
    {
        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }
        public int lokacijaID { get; set; }

        public LokacijaKorisnik() { }   
    }
}
