using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optika_Lentium.Models
{
    public class ValidacijaProizvoda
    {
        [Key]
        public int valProizvodId { get; set; }      
        public Boolean uspjesnaValidacija {  get; set; }    
        public int stanjeProizvoda {  get; set; }

        [ForeignKey("Narucivanje")]
        public int narucivanjeId { get; set; }
        public ValidacijaProizvoda() { }    

    }
}