
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Data;
using Optika_Lentium.Models;
using System.Drawing;

namespace Optika_Lentium.Patterns
{
    public class ProizvodService : IProizvod
    {
        private readonly ApplicationDbContext _context;
        private List<Proizvod> sviProizvodi = new List<Proizvod>();
        private List<Proizvod> filteredProizvodi = new List<Proizvod>();

        public ProizvodService(ApplicationDbContext context)
        {
            _context = context;
            sviProizvodi = _context.Proizvod.ToList();
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
                if (p.tip != null && p.tip.ToString() == tip)
                {
                    filteredProizvodi.Add(p);
                }
            }

            if (pol != null && pol != "" && pol != "Null")
            {
                polFilter = true;
                foreach (Proizvod p in filteredProizvodi)
                {
                    if (p.kategorija != null && p.kategorija.ToString() == pol)
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
                        if (p.nazivProizvod.ToString().ToLower() == brend.ToLower())
                        {
                            filteredProizvodi2.Add(p);
                        }
                    }
                } else
                {
                    foreach (Proizvod p in filteredProizvodi)
                    {
                        if (p.nazivProizvod.ToString().ToLower() == brend.ToLower())
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

        /*
        private List<Proizvod> SeedProductList()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            proizvodi.Add(new Proizvod(1, "Acuvue" , 80.00,  "https://i.ibb.co/XDsBJvn/ACUVUE-Oasys.webp",Kategorija.Djeciji,Tip.Lece));
            proizvodi.Add(new Proizvod(2,"AIR Optix",50.00,  "https://i.ibb.co/qNYthP5/Alcon-AIROPTIXplus-Hydra-Glyde.webp",Kategorija.Zenski, Tip.Lece));
            proizvodi.Add(new Proizvod(3,"Soft Lens",69.00, "https://i.ibb.co/BGXz95W/BL-Sof-Lens-59.webp", Kategorija.Muski, Tip.Lece));
            proizvodi.Add(new Proizvod(4,"Renu MultiPlus",26.00,"https://i.ibb.co/R64Ck8R/Renu.webp", Kategorija.Muski, Tip.Lece));
            proizvodi.Add(new Proizvod(5, "PureVision", 90.00, "https://i.ibb.co/rFhn1Yt/Pure-Vision-670x.webp", Kategorija.Muski, Tip.Lece));
            proizvodi.Add(new Proizvod(6, "Futrola", 12.00, "https://i.ibb.co/D59XD2p/Futrola-Centrostyle-crvena-2-940x.webp", Kategorija.Zenski, Tip.Asesoari));
            proizvodi.Add(new Proizvod(7, "Lancic", 26.00, "https://i.ibb.co/YkPpJn8/lancic.webp", Kategorija.Zenski, Tip.Asesoari));
            proizvodi.Add(new Proizvod(8, "Anti-fog gel", 20.00, "https://i.ibb.co/bsQ05Bc/Anti-Fog-gel.webp", Kategorija.Zenski, Tip.Asesoari));
            proizvodi.Add(new Proizvod(9, "Esprit", 215.00, "https://i.ibb.co/K0nRyqP/Esprit01.webp", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(10, "Esprit", 215.00, "https://i.ibb.co/HCtZbGJ/esprit02.webp", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(11, "Ray Ban", 260.00, "https://i.ibb.co/71bYhBz/rayban01.webp", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(12, "Tom Tailor", 175.00, "https://i.ibb.co/Fzr0KGZ/tomtailor01.webp", Kategorija.Muski, Tip.Okviri));
            proizvodi.Add(new Proizvod(13, "Esprit", 179.00, "https://i.ibb.co/DG4Ck2S/esprit03.webp", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(14, "Dolce&Gabbana", 460.00, "https://i.ibb.co/5rnYXrC/dolcegabana01.webp", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(15, "Vogue", 190.00, "https://i.ibb.co/dctyzbx/vogue01.webp", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(16, "Vogue", 190.00, "https://i.ibb.co/XYgx1sF/vogue02.webp", Kategorija.Zenski, Tip.Okviri));
            proizvodi.Add(new Proizvod(17, "Tom Tailor", 185.00, "https://i.ibb.co/tL2v8r3/tomtailor02.webp", Kategorija.Djeciji, Tip.Okviri));
            proizvodi.Add(new Proizvod(18, "Tom Tailor", 164.00, "https://i.ibb.co/Zdf6Wg3/tomtailor03.webp", Kategorija.Djeciji, Tip.Okviri));
            proizvodi.Add(new Proizvod(19, "Dolce&Gabbana", 585.00, "https://i.ibb.co/RSkHK7x/dolcegabana02.webp", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(20, "Ray Ban", 345.00, "https://i.ibb.co/Y0SYs25/rayban02.webp", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(21, "Ray Ban", 325.00, "https://i.ibb.co/9p1HcrJ/rayban03.webp", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(22, "Tom Tailor", 225.00, "https://i.ibb.co/9p1HcrJ/rayban03.webp", Kategorija.Muski, Tip.Naocale));
            proizvodi.Add(new Proizvod(23, "Dolce&Gabbana", 560.00, "https://i.ibb.co/dtS8R0w/dolcegabana03.webp", Kategorija.Zenski, Tip.Naocale));
            proizvodi.Add(new Proizvod(24, "Dolce&Gabbana", 585.00, "https://i.ibb.co/6rGV3hP/dolcegabana04.webp", Kategorija.Zenski, Tip.Naocale));
            proizvodi.Add(new Proizvod(25, "Ray Ban", 325.00, "https://i.ibb.co/ZL6bpB7/rayban04.webp", Kategorija.Zenski, Tip.Naocale));
            proizvodi.Add(new Proizvod(26, "Ray Ban", 280.00, "https://i.ibb.co/TcRZ6Qn/rayban05.webp", Kategorija.Zenski, Tip.Naocale));
            proizvodi.Add(new Proizvod(27, "Tom Tailor", 215.00, "https://i.ibb.co/YjpXVPs/tomtailor05.webp", Kategorija.Zenski, Tip.Naocale));
            proizvodi.Add(new Proizvod(28, "Tom Tailor", 149.00, "https://i.ibb.co/8KmpktJ/tomtailor06.webp", Kategorija.Djeciji, Tip.Naocale));
            proizvodi.Add(new Proizvod(29, "Tom Tailor", 149.00, "https://i.ibb.co/wdf77x6/tomtailor07.webp", Kategorija.Djeciji, Tip.Naocale));


            return proizvodi.ToList();
        }*/

    }
}
