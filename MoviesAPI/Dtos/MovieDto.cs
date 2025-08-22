using MoviesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos
{
    public class MovieDto
    {

        [MaxLength(100)]
        public string Title { get; set; }

        public int Year { get; set; }


        [MaxLength(500)]
        public string Description { get; set; }

        public double Rate { get; set; }

        public IFormFile Poster { get; set; }

        public int GenreId { get; set; }

    }
}
