using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class Popust
    {
        [Key]
        public int popustId { get; set; }   
        public int brojOstvarenihNarudzbi {  get; set; }

        [ForeignKey("Placanje")]
        public int placanjeId { get; set; }
        public Popust() { }

        public void IzracunajPopust() { 
        }

    }
}
