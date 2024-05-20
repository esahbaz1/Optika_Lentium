using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Optika_Lentium.Models
{
    public class NoviKorisnik
    {
        [Key]
        public int korisnikId { get; set; }
		public int kupacId { get; set; }
		public int radnikId { get; set; }
		public int vlasnikId { get; set; }
		public string ime { get; set; }
		public string prezime { get; set; }
		public string sifra { get; set; }

	}
}
