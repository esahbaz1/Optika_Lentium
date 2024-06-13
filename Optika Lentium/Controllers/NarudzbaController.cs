using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Data;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;
using System.Security.Claims;
using System.Text.Json;

namespace Optika_Lentium.Controllers
{
    
    public class NarudzbaController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<NarudzbaController> _logger;
		private readonly INarudzba _narudzbaService;

		public NarudzbaController(ILogger<NarudzbaController> logger, INarudzba p, ApplicationDbContext context)
		{
			_context = context;
			_logger = logger;
			_narudzbaService = p;
		}

		public IActionResult Index()
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

		public IActionResult MeniView()
		{
			return View();
		}

        public IActionResult HomeView()
        {
            return View();
        }

        public IActionResult LoginView()
        {
            return View();
        }
		[Authorize]
		[HttpPost]
		public IActionResult AddToCart(int productId)
		{
			var product = _context.Proizvod.Find(productId);
			if (product != null)
			{
				var cart = GetCartFromSession();
				cart.Add(product);
				SaveCartToSession(cart);
			}
			return RedirectToAction("KorpaView");
		}

		[HttpPost]
		public IActionResult RemoveFromCart(int productId)
		{
			var cart = GetCartFromSession();
			var product = cart.FirstOrDefault(p => p.proizvodId == productId);
			if (product != null)
			{
				cart.Remove(product);
				SaveCartToSession(cart);
				return RedirectToAction("KorpaView");
			}
			return NotFound();
		}
		[Authorize]
		public IActionResult KorpaView()
		{
			var cart = GetCartFromSession();
			double ukupnaCijena = cart.Sum(p => p.cijena);
			double popust = 0;
			double ukupno = ukupnaCijena;
			if (ukupnaCijena > 300)
			{
				popust = 10;
				ukupno -= 0.1 * ukupnaCijena;
			}
			ViewBag.ukupno = ukupno;
			ViewBag.UkupnaCijena = ukupnaCijena;
			ViewBag.popust = popust;
			return View(cart);
		}

		private List<Proizvod> GetCartFromSession()
		{
			var cartJson = HttpContext.Session.GetString("Cart");
			if (cartJson == null)
			{
				return new List<Proizvod>();
			}
			return JsonSerializer.Deserialize<List<Proizvod>>(cartJson);
		}

		private void SaveCartToSession(List<Proizvod> cart)
		{
			var cartJson = JsonSerializer.Serialize(cart);
			HttpContext.Session.SetString("Cart", cartJson);
		}
	}
}
