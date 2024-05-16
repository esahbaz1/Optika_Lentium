using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;


namespace Optika_Lentium.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProizvod _proizvodService;

        public HomeController(ILogger<HomeController> logger, IProizvod p)
        {
            _logger = logger;
            _proizvodService = p;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignupView()
        {
            return View();
        }
        public IActionResult LoginView()
        {
            return View();
        }
        public IActionResult KontaktView()
        {
            return View();
        }

        public IActionResult ZakPregledaView()
        {
            return View();
        }

        public IActionResult LokacijaView()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}