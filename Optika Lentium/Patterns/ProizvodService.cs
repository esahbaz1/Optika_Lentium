
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


        public void FilterProducts(string tip, string pol, string brend, string cijena)
        {
            filteredProizvodi = new List<Proizvod>();
            List<Proizvod>filteredProizvodi1 = new List<Proizvod>();
            List<Proizvod> filteredProizvodi2 = new List<Proizvod>();
            List<Proizvod> filteredProizvodi3 = new List<Proizvod>();
            bool polFilter = false, brendFilter = false, cijenaFilter = false;

            foreach (Proizvod p in sviProizvodi)
            {
                if (p.tip.ToString() == tip)
                {
                    filteredProizvodi.Add(p);
                }
            }

            if (pol != null && pol != "" && pol != "Null")
            {
                polFilter = true;
                foreach (Proizvod p in filteredProizvodi)
                {
                    if (p.kategorija.ToString() == pol)
                    {
                        filteredProizvodi1.Add(p);
                    }
                }
            }
            
            if (brend != null && brend != "" && brend != "null" && brend != "svi")
            {
                brendFilter = true;
                if(filteredProizvodi1.Count > 0)
                {
                    foreach (Proizvod p in filteredProizvodi1)
                    {
                        if (p.nazivProizvod.ToString() == brend)
                        {
                            filteredProizvodi2.Add(p);
                        }
                    }
                } else
                {
                    foreach (Proizvod p in filteredProizvodi)
                    {
                        if (p.nazivProizvod.ToString() == brend)
                        {
                            filteredProizvodi2.Add(p);
                        }
                    }
                }
                
            }

            if (cijena != null && cijena != "" && cijena != "null" && cijena != "sve")
            {
                cijenaFilter = true;
                double cijenaMin = 0;
                double cijenaMax = 0;

                if (cijena.Equals("0-100"))
                {
                    cijenaMin = 0.0;
                    cijenaMax = 100.0;
                }
                else if (cijena.Equals("100-200"))
                {
                    cijenaMin = 100.0;
                    cijenaMax = 200.0;
                }
                else if (cijena.Equals("200-300"))
                {
                    cijenaMin = 200.0;
                    cijenaMax = 300.0;
                }
                else if (cijena.Equals("300-400"))
                {
                    cijenaMin = 300.0;
                    cijenaMax = 400.0;
                }
                else if (cijena.Equals("400-500"))
                {
                    cijenaMin = 400.0;
                    cijenaMax = 500.0;
                }

                if (filteredProizvodi2.Count > 0)
                {
                    foreach (Proizvod p in filteredProizvodi2)
                    {
                        if (p.cijena >= cijenaMin && p.cijena < cijenaMax)
                        {
                            filteredProizvodi3.Add(p);
                        }
                    }
                }
                else if (filteredProizvodi1.Count > 0)
                {
                    foreach (Proizvod p in filteredProizvodi1)
                    {
                        if (p.cijena >= cijenaMin && p.cijena < cijenaMax)
                        {
                            filteredProizvodi3.Add(p);
                        }
                    }
                }
                else
                {
                    foreach (Proizvod p in filteredProizvodi)
                    {
                        if (p.cijena >= cijenaMin && p.cijena < cijenaMax)
                        {
                            filteredProizvodi3.Add(p);
                        }
                    }
                }

            }

            if (polFilter)
            {
                filteredProizvodi=filteredProizvodi1.ToList();
            }
            if (brendFilter)
            {
                filteredProizvodi = filteredProizvodi2.ToList();
            }
            if (cijenaFilter)
            {
                filteredProizvodi = filteredProizvodi3.ToList();
            }
        }

        
        private List<Proizvod> SeedProductList()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            proizvodi.Add(new Proizvod(1, "Ray Ban", 150.00, "", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(2, "Hugo Boss", 350.00, "", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(3, "Vogue", 250.00, "", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(4, "Alcon", 50.00,  "", Kategorija.Muski, Tip.Lece));
            proizvodi.Add(new Proizvod(5, "Nike", 15.00, "", Kategorija.Zenski, Tip.Asesoari));
            proizvodi.Add(new Proizvod(6, "Gucci", 500.00, "", Kategorija.Zenski, Tip.Naocale));

            return proizvodi.ToList();
        }

    }
}
