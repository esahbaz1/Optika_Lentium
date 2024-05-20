using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Data;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;

namespace Optika_Lentium.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly ILogger<ProizvodController> _logger;
        private readonly IProizvod _proizvodService;

        public ProizvodController(ILogger<ProizvodController> logger, IProizvod p)
        {
            _logger = logger;
            _proizvodService = p;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MeniView(string tip, string pol)
        {
            if (pol == null || pol == "")
            {
                _proizvodService.FilterProductsByTip(tip);
            }
            else
            {
                _proizvodService.FilterProductsByPol(tip, pol);
            }
            return View();
        }

        public IActionResult PregledProView()
        {
            return View();
        }

        public IActionResult KontaktView()
        {
            return View();
        }

        public IActionResult LoginView()
        {
            return View();
        }
        public IActionResult SignupView()
        {
            return View();
        }

        public IActionResult Placanje()
        {
            return View();
        }
        public IActionResult KorpaView()
        {
            return View();
        }

    }
}