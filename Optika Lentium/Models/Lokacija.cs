using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Lokacija
    {
        public int lokacijaID { get; set; }
        public string lokacijaOptikeURL { get; set; }
        public string lokacijaKorisnikaURL { get; set; }
        
        public Lokacija() { }
        public void lokacijaKorisnika() { }
        public void najblizaLokacija() { }
    }
}
