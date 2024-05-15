using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;

namespace Optika_Lentium.Models
{
    public class Proizvod
    {
        public int proizvodId { get; set; } 
        public string nazivProizvod {  get; set; }  
        public double cijena { get; set; }  
        public string slikaURL { get; set; }    
        public enum Kategorija
        {
          
        }
        public enum Tip
        {

        }
        public Proizvod() { }   

    }
}
