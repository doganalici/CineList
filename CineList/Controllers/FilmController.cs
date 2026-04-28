using CineList.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineList.Controllers
{
    public class FilmController : Controller
    {
        
        public IActionResult Index()
        {
            return View(FilmStore.Filmler);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {
            film.Id = FilmStore.Filmler.Count + 1;
            FilmStore.Filmler.Add(film);
            return RedirectToAction("Index");
        }

        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film film)
        {
            film.Id = FilmStore.Filmler.Count + 1;
            FilmStore.Filmler.Add(film);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateFilm(int? id)
        {
            var seciliFilm = FilmStore.Filmler.FirstOrDefault(f => f.Id == id);
            ViewBag.SeciliFilm = seciliFilm;
            return View(FilmStore.Filmler);
        }
        [HttpPost]
        public IActionResult UpdateFilm(Film film)
        {
            var existingFilm = FilmStore.Filmler.FirstOrDefault(f => f.Id == film.Id);
            if (existingFilm != null)
            {
                existingFilm.Name = film.Name;
                existingFilm.Genre = film.Genre;
                existingFilm.Director = film.Director;
                existingFilm.Status = Request.Form["Status"].ToString().Contains("true");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFilm(int? id)
        {
            var seciliFilm = FilmStore.Filmler.FirstOrDefault(f => f.Id == id);
            ViewBag.SilinecekFilm = seciliFilm;
            return View(FilmStore.Filmler);
        }
        [HttpPost]
        public IActionResult DeleteFilm(int id)
        {
            var filmToDelete = FilmStore.Filmler.FirstOrDefault(f => f.Id == id);
            if (filmToDelete != null)
            {
                FilmStore.Filmler.Remove(filmToDelete);
            }
            return RedirectToAction("Index");
        }

    }
}
