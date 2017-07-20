using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _dbContext;

        //Constructor initilizes Context for this Controller
        public MoviesController()
        {
            _dbContext = new VidlyContext();
        }

        // GET: Movies
        [Route("movies/random")]
        public ActionResult Random()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Star World"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movies,
                //Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(string name, int id)
        {
            var model = new List<Movie>()
            {
                new Movie {Id = id, Name = name}
            };


            //return Content();
            return View(model);
        }

        public ActionResult Index()
        {
            try
            {
                var movies = _dbContext.Movies
                    .Include(g => g.Genre)
                    .Select(Mapper.Map<Movie, MovieViewModel>)
                    .ToList();
                return View(movies);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Detail(int? id)
        {
            try
            {
                if (id == null)
                    return RedirectToAction("Index");
                var movie = _dbContext.Movies
                    .Include(m => m.Genre)
                    .Select(Mapper.Map<Movie, MovieViewModel>)
                    .FirstOrDefault(i => i.Id == id);
                return View(movie);

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}