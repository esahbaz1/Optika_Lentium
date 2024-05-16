using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public class ProizvodService : IProizvod
    {
        private List<Proizvod> sviProizvodi = new List<Proizvod>();
        private List<Proizvod> filteredProizvodi = new List<Proizvod>();

        public ProizvodService()
        {
            sviProizvodi = SeedProductList();
            /*sviProizvodi.Add(new Proizvod(1, "Ray Ban", 150.00, "", Kategorija.Muski, Tip.Naocale));
            sviProizvodi.Add(new Proizvod(2, "Hugo Boss", 350.00, "", Kategorija.Zenski, Tip.Okviri));
            sviProizvodi.Add(new Proizvod(3, "Vogue", 250.00, "", Kategorija.Muski, Tip.Okviri));*/
            filteredProizvodi = sviProizvodi.ToList();
        }

        public List<Proizvod> GetAllProducts()
        {
            return sviProizvodi;
        }

        public List<Proizvod> GetFilteredProducts()
        {
            return filteredProizvodi;
        }

        public void FilterProductsByTip(string tip)
        {
            
            filteredProizvodi = new List<Proizvod>();
            foreach(Proizvod p in sviProizvodi)
            {
                if(p.tip.ToString() == tip)
                {
                    filteredProizvodi.Add(p);
                }
            }
            
        }

        private List<Proizvod> SeedProductList()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            proizvodi.Add(new Proizvod(1, "Ray Ban", 150.00, "", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(2, "Hugo Boss", 350.00, "", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(3, "Vogue", 250.00, "", Kategorija.Muski, Tip.Okviri));

            return proizvodi.ToList();
        }
    }
}
