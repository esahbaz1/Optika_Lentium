using Optika_Lentium.Models;
using Optika_Lentium.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Optika_Lentium.Paterni
{
    public class OpadajuciPoredakCijena : ISort
    {
        public List<Proizvod> Sort(List<Proizvod> Proizvods)
        {
            List<Proizvod> sortedProizvods = Proizvods.OrderByDescending(p => p.cijena).ToList();
            return sortedProizvods;
        }
    }
}