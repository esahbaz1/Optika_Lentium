using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Lokacija
    {
        [Key]
        public int lokacijaId { get; set; }
        public string lokacijaOptikeURL { get; set; }
        public string lokacijaKorisnikaURL { get; set; }
        
        public Lokacija() { }
        public void lokacijaKorisnika() { }
        public void najblizaLokacija() { }
    }
}
