using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class NacinPlacanja
    {
        [Key]
        public int Id { get; set; }
        public string vrsta { get; set; }

        [ForeignKey("Placanje")]
        public int placanjeId { get; set; } 
        public NacinPlacanja() { }

    }
}
