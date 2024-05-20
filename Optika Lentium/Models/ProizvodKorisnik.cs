using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class ProizvodKorisnik
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NoviKorisnik")]
        public int korisnikId { get; set; } 
        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }

        [ForeignKey("Proizvod")]
        public int proizvodId { get; set; }
        public ProizvodKorisnik() { }   

    }
}
