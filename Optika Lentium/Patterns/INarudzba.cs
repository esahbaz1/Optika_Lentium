using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public interface INarudzba
    {
        void AddToCart(Proizvod proizvod);
        void RemoveFromCart(int proizvodId);
        List<Proizvod> GetCartItems();
        void ClearCart();
        

    }
}