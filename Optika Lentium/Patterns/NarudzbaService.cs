
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public class NarudzbaService : INarudzba
    {
        private readonly List<Proizvod> _cartItems = new List<Proizvod>();

        public void AddToCart(Proizvod proizvod)
        {
            _cartItems.Add(proizvod);
        }

        public void RemoveFromCart(int proizvodId)
        {
            var item = _cartItems.FirstOrDefault(p => p.proizvodId == proizvodId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public List<Proizvod> GetCartItems()
        {
            return _cartItems;
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

    }
}
