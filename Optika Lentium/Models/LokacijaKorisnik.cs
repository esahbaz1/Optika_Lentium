using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class LokacijaKorisnik
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NoviKorisnik")]
        public int korisnikId { get; set; }     

        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }

        [ForeignKey("Lokacija")]
        public int lokacijaId { get; set; }

        public LokacijaKorisnik() { }   
    }
}
