using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Popust
    {
        public int popustId { get; set; }   
        public int brojOstvarenihNarudzbi {  get; set; }    
        public Popust() { }

        public void IzracunajPopust() { 
        }

    }
}
