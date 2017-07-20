using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}