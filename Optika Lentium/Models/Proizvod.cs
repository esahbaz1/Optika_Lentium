using Optika_Lentium.Models;
using Optika_Lentium.Patterns;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public enum Kategorija
    {
        Muski,
        Zenski,
        Djeciji
    }
    public enum Tip
    {
        Okviri,
        Naocale,
        Lece,
        Asesoari
    }
    public class Proizvod : IPrototip<Proizvod>
    {
        [Key]
        public int proizvodId { get; set; }
        public string nazivProizvod { get; set; }
        public double cijena { get; set; }
        public string slikaURL { get; set; }
        public string? kategorija { get; set; }
        public string? tip { get; set; }

        public Proizvod() { }

        public Proizvod(int proizvodId, string nazivProizvod, double cijena, string slikaURL, Kategorija kategorija, Tip tip)
        {
            this.proizvodId = proizvodId;
            this.nazivProizvod = nazivProizvod;
            this.cijena = cijena;
            this.slikaURL = slikaURL;
            this.kategorija = kategorija.ToString();
            this.tip = tip.ToString();
        }
        public Proizvod Kloniraj()
        {
            return new Proizvod
            {
                proizvodId = this.proizvodId,
                nazivProizvod = this.nazivProizvod,
                cijena = this.cijena,
                slikaURL = this.slikaURL,
                kategorija = this.kategorija,
                tip = this.tip
            };
        }
    }
}