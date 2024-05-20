
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Models;

namespace Optika_Lentium.Patterns
{
    public class NarudzbaService : INarudzba
    {
        private List<Narucivanje> korpa = new List<Narucivanje>();
        private List<Narucivanje> korpaFiltered = new List<Narucivanje>();

        public NarudzbaService()
        {
            korpa = new List<Narucivanje>();
            korpaFiltered = korpa.ToList();
        }

		public List<Narucivanje> GetCart(int idKorisnika)
        {
            return korpa;
        }

		public void AddToCart(int idKorisnika, int idProizvoda)
		{
            korpa.Add(new Narucivanje()
            {
                proizvodId = idProizvoda,
                narucivanjeId = korpa.Count+1,
                korisnik = new Korisnik() { korisnikId = idKorisnika }
            });
		}

	}
}
