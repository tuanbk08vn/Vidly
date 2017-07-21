using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.DAL;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private VidlyContext _dbContext;

        public NewRentalsController()
        {
            _dbContext = new VidlyContext();
        }

        // GET /api/newrentals
        public IHttpActionResult GetRentals()
        {
            var rental = new List<NewRentalDto>();
            rental = _dbContext.Rentals
                .Include(m => m.Movie)
                .Select(Mapper.Map<Rental, NewRentalDto>)
                .ToList();
            if (!rental.Any())
                return NotFound();
            return Ok();
        }

        // POST /api/newrentals
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _dbContext.Customers
                .Select(Mapper.Map<Customer, CustomerViewModel>)
                .FirstOrDefault(m => m.Id == newRental.CustomerId);
            var movies = _dbContext.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id ?? 0))
                .Select(Mapper.Map<Movie, MovieViewModel>);
            foreach (var movie in movies)
            {
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _dbContext.Rentals.Add(rental);
            }
            return Ok();
            //var rental = Mapper.Map<NewRentalDto, Rental>(newRental);

            //_dbContext.Rentals.Add(rental);
            //_dbContext.SaveChanges();

            //newRental.Id = rental.Id;
            // return Created(new Uri(Request.RequestUri + "/" + rental.Id), newRental);
            // }
        }
    }
}