using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public interface IProizvod
    {
        List<Proizvod> GetAllProducts();
        void FilterProductsByTip(string tip);
        public List<Proizvod> GetFilteredProducts();
    }
}
