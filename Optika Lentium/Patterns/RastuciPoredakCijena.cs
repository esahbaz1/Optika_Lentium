using Optika_Lentium.Models;
using System.Collections.Generic;
using System.Linq;
namespace Optika_Lentium.Patterns
{
    public class RastuciPoredakCijena : ISort
    {
        public List<Proizvod> Sort(List<Proizvod> Proizvods)
        {
            List<Proizvod> sortedProizvods = Proizvods.OrderBy(p => p.cijena).ToList();
            return sortedProizvods;
        }
    }
}
