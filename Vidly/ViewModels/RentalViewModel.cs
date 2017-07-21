using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class RentalViewModel
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