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
        public IActionResult MeniView(string tip)
        {
            _proizvodService.FilterProductsByTip(tip);
            return View();
        }

        public IActionResult PregledProView()
        {
            return View();
        }
    }
}
