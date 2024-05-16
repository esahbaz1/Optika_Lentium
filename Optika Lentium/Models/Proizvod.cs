using Optika_Lentium.Models;
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
    public class Proizvod
    {
        public int proizvodId { get; set; } 
        public string nazivProizvod {  get; set; }  
        public double cijena { get; set; }  
        public string slikaURL { get; set; }
        public Kategorija kategorija { get; set; }
        public Tip tip { get; set; }

        public Proizvod() { }

        public Proizvod(int proizvodId, string nazivProizvod, double cijena, string slikaURL, Kategorija kategorija, Tip tip)
        {
            this.proizvodId = proizvodId;
            this.nazivProizvod = nazivProizvod;
            this.cijena = cijena;
            this.slikaURL = slikaURL;
            this.kategorija = kategorija;
            this.tip = tip;
        }
    }
}
