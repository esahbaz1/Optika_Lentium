using Optika_Lentium.Models;
using System.Collections.Generic;
namespace Optika_Lentium.Patterns
{
    public interface ISort
    {
        List<Proizvod> Sort(List<Proizvod> Proizvods);
    }
}
