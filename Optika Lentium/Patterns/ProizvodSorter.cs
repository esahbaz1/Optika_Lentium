using Optika_Lentium.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Optika_Lentium.Paterni;
using Optika_Lentium.Paterni;
using Optika_Lentium.Patterns;
namespace Optika_Lentium.Paterni
{
    public class ProizvodSorter
    {
        private ISort _sortStrategy;

        public void SetSortStrategy(ISort sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }


        public List<Proizvod> Sort(List<Proizvod> Proizvods, string sortOption)
        {
            Dictionary<string, ISort> sortStrategyMap = new Dictionary<string, ISort>()
    {
        { "AscendingPrice", new RastuciPoredakCijena() },
        { "DescendingPrice", new OpadajuciPoredakCijena() }
    };

            if (string.IsNullOrEmpty(sortOption) || !sortStrategyMap.ContainsKey(sortOption))
            {
                // Default sort strategy (ascending by name)
                sortOption = "AscendingName";
            }
            else
                _sortStrategy = sortStrategyMap[sortOption];
            return _sortStrategy.Sort(Proizvods);
        }

    }
}
