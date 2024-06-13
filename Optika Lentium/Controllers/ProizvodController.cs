using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Data;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;
using System.Text.Json;

namespace Optika_Lentium.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProizvodController> _logger;
        private readonly IProizvod _proizvodService;

        public ProizvodController(ILogger<ProizvodController> logger, IProizvod p, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _proizvodService = p;
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
            double  popust = 0;
            double ukupno = ukupnaCijena;
            if (ukupnaCijena > 300) {
                popust = 10;
                ukupno -=0.1*ukupnaCijena;
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
