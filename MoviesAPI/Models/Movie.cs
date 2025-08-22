using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public int Year { get; set; }


        [MaxLength(500)]
        public string Description { get; set; }

        public double Rate { get; set; }

        public byte[] Poster {  get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
