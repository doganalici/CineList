using System.Diagnostics;
using CineList.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ToplamFilm = FilmStore.Filmler.Count;
            ViewBag.Izlendi = FilmStore.Filmler.Count(f => f.Status);
            ViewBag.Izlenmedi = FilmStore.Filmler.Count(f => !f.Status);
            ViewBag.SonFilmler = FilmStore.Filmler.TakeLast(10).ToList();
            return View(FilmStore.Filmler);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
