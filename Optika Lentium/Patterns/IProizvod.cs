using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public interface IProizvod
    {
        List<Proizvod> GetAllProducts();
        public void FilterProducts(string tip, string pol,string brend, string cijena);
        public List<Proizvod> GetFilteredProducts();

        void dodajProizvod(Proizvod proizvod);
    }
  
}