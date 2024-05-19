using Microsoft.AspNetCore.Mvc;
using Optika_Lentium.Models;
using Optika_Lentium.Patterns;

namespace Optika_Lentium.Controllers
{
	public class NarudzbaController : Controller
	{
		private readonly ILogger<NarudzbaController> _logger;
		private readonly IProizvod _proizvodService;

		public NarudzbaController(ILogger<NarudzbaController> logger, IProizvod p)
		{
			_logger = logger;
			_proizvodService = p;
		}

		public IActionResult Index()
		{
			return View();
		}

		public List<IProizvod> ListaProizvoda = new List<IProizvod>();

		public IActionResult KorpaView()
		{
			ListaProizvoda.Add(_proizvodService);
			return View();
		}

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
