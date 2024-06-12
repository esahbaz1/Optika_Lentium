using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
        private readonly INarudzba _narudzbaService;

        public ProizvodController(ILogger<ProizvodController> logger, IProizvod p, INarudzba _narudzbaServices)
        {
            _logger = logger;
            _proizvodService = p;
            _narudzbaService = _narudzbaServices;

        }

    public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MeniView(string tip, string pol, string brend, string cijena)
        {
            _proizvodService.FilterProducts(tip, pol, brend, cijena);
            var availableProducts = _proizvodService.GetAvailableProducts();
            _logger.LogInformation(tip + pol + brend + cijena);
            _logger.LogInformation(availableProducts.Count.ToString());
            return View(availableProducts);
        }
        [Authorize]
        public async Task<IActionResult> PregledProView(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var product = _proizvodService.GetAllProducts().Find(p => p.proizvodId == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
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
        [Authorize]
        public IActionResult Uspjesnoplacanje()
		{
			return View();
		}
        [Authorize]
        public IActionResult Neuspjesnoplacanje()
		{
			return View();
		}
        [Authorize]
        public IActionResult Placanje()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult AddToCart(Proizvod proizvodId)
        {
            _logger.LogInformation($"Adding product {proizvodId} to cart.");
            _narudzbaService.AddToCart(proizvodId);
            return RedirectToAction("KorpaView");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int proizvodId)
        {
            _narudzbaService.RemoveFromCart(proizvodId);
            return RedirectToAction("KorpaView");
        }
         [Authorize]
        public IActionResult KorpaView()
        {
            var cartItems = _narudzbaService.GetCartItems();
            return View(cartItems);
        }
    }
}