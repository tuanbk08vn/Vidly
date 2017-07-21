using System;
using System.ComponentModel.DataAnnotations;
using Vidly.ViewModels;

namespace Vidly.Models
{
    public class Rental
    {
        public int? Id { get; set; }

        [Required]
        public CustomerViewModel Customer { get; set; }

        [Required]
        public MovieViewModel Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}