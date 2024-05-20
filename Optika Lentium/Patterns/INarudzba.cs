using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public interface INarudzba
    {
        List<Narucivanje> GetCart(int idKorisnika);
		void AddToCart(int idKorisnika, int idProizvoda);

	}
}