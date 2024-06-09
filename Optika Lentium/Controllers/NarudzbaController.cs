using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;
using System.Security.Claims;

namespace Optika_Lentium.Controllers
{
    
    public class NarudzbaController : Controller
	{
		private readonly ILogger<NarudzbaController> _logger;
		private readonly INarudzba _narudzbaService;

		public NarudzbaController(ILogger<NarudzbaController> logger, INarudzba p)
		{
			_logger = logger;
			_narudzbaService = p;
		}

		public IActionResult Index()
		{
			return View();
		}
        [Authorize]
        public IActionResult KorpaView()
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
		public async Task<IActionResult> AddToCart(int id)
		{
			_narudzbaService.AddToCart(1, id);
			return Json(new { message = "Radi!" });

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
    }
}
