using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optika_Lentium.Models
{
    public class Korisnik : IdentityUser
    {
        public int korisnikId { get; set; }     
        public int kupacId { get; set; }
        public int radnikId { get; set; }
        public int vlasnikId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
		     
        public string sifra { get; set; }
        
        //public Korisnik() { }   
       
    }
}
