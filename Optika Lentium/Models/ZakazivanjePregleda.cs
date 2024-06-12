using Optika_Lentium.Models;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optika_Lentium.Models
{
    public class ZakazivanjePregleda
    {
       [Key]
        public int pregledId {  get; set; } 
        public string imePrezime { get; set; }  
        public string email { get; set; } 
        public string brojTelefona {  get; set; } 
        public string nacinKontakta { get; set; }   
        public string danPregleda { get; set; } 
        public string vrijemePregleda { get; set; }
        public ZakazivanjePregleda() { }

    }
}