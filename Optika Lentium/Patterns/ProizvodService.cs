
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
            foreach (Proizvod p in sviProizvodi)
            {
                if (p.tip.ToString() == tip)
                {
                    filteredProizvodi.Add(p);
                }
            }

        }

        public void FilterProductsByPol(string tip, string pol)
        {
            filteredProizvodi = new List<Proizvod>();
            foreach (Proizvod p in sviProizvodi)
            {
                if (p.tip.ToString() == tip && p.kategorija.ToString() == pol)
                {
                    filteredProizvodi.Add(p);
                }
            }
        }

        public void FilterProductsByBrend(string brend)
        {
            List<Proizvod> filteredProizvodiByBrend = new List<Proizvod>();
            foreach (Proizvod p in filteredProizvodi)
            {
                if (p.brend == brend)
                {
                    filteredProizvodiByBrend.Add(p);
                }
            }
            filteredProizvodi = filteredProizvodiByBrend.ToList();
        }
        private List<Proizvod> SeedProductList()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            proizvodi.Add(new Proizvod(1, "Ray Ban Naocale", 150.00, "Ray Ban", "", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(2, "Hugo Boss Okvir", 350.00, "Hugo Boss", "", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(3, "Vogue Okvir", 250.00, "Vogue", "", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(4, "AIR OPTIX plus HydraGlyde", 50.00, "Alcon", "", Kategorija.Muski, Tip.Lece));
            proizvodi.Add(new Proizvod(5, "Futrola Centro Crvena\r\n", 15.00, "Nike", "", Kategorija.Zenski, Tip.Asesoari));
            proizvodi.Add(new Proizvod(6, "Gucci Naocale", 500.00, "Gucci", "", Kategorija.Zenski, Tip.Naocale));

            return proizvodi.ToList();
        }

    }
}
