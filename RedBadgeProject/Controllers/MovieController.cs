using Movie.Model;
using Movie.Models;
using Movie.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.Controllers
{
    public class MovieController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);

            var model = service.GetMovies();

            return View(model);

            //var model = new MovieListItem[0];
            //return View(model);
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }


        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateMovieService();

            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your movie was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Movie could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMovieService();
            var detail = service.GetMovieById(id);
            var model =
                new MovieEdit
                {
                    MovieId = detail.MovieId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Rating = detail.Rating,
                    Cast = detail.Cast,
                    Genre = detail.Genre
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMovieService();

            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            var service = CreateMovieService();

            service.DeleteMovie(id);

            TempData["SaveResult"] = "Your movie was deleted";

            return RedirectToAction("Index");

        }


        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }
    }
}
