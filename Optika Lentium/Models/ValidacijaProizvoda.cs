using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class ValidacijaProizvoda
    {
        public int valproizvodId { get; set; }      
        public Boolean uspjesnaValidacija {  get; set; }    
        public int stanjeProizvoda {  get; set; }   
        public ValidacijaProizvoda() { }    

    }
}