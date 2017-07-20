using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Range(0, Int32.MaxValue)]
        public int NumberInStock { get; set; }
    }
}
