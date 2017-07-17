using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("movies/random")]
        public ActionResult Random()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Star World"}

            };

            //var customers = new List<Customer>
            //{
            //    new Customer {Name = "Customer 1"},
            //    new Customer {Name = "Customer 2"},
            //    new Customer {Name = "Customer 3"},
            //    new Customer {Name = "Customer 4"},
            //    new Customer {Name = "Customer 5"},
            //    new Customer {Name = "Customer 6"}
            //};

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

        public ActionResult Index(int? pageIndex, string SortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrEmpty(SortBy))
                SortBy = "Name";

            return Content(String.Format("pageIndex = {0} & SortBy = {1}", pageIndex, SortBy));
        }
    }
}