using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public interface IProizvod
    {
        List<Proizvod> GetAllProducts();
        public void FilterProductsByTip(string tip);
        public void FilterProductsByPol(string tip, string pol);
        public void FilterProductsByBrend(string brend);

        public List<Proizvod> GetFilteredProducts();

    }
}