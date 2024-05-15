using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class ProizvodKorisnik
    {
        public int kupacId { get; set; }
        public int radnikID { get; set; }
        public int vlasnikID { get; set; }
        public int proizvodID { get; set; }
        public ProizvodKorisnik() { }   

    }
}
