using Microsoft.EntityFrameworkCore;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Serves
{
    public class MovieServes : IMovieServes
    {
        private readonly ApplicationDbContext _context;

        public MovieServes(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetByGenreId(int genreId)
        {
            return await _context.Movies.Where(movie => movie.GenreId == genreId ).ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie;
        }

        public async Task<Movie> CreateMovie(MovieDto dto)
        {
            using var stream = new MemoryStream();
            await dto.Poster.CopyToAsync(stream);

            var genre = await _context.Genres.FindAsync(dto.GenreId);

            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                GenreId = dto.GenreId,
                Rate = dto.Rate,
                Year = dto.Year,
                Poster = stream.ToArray(),
                Genre = genre
            };

            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();

            return movie;
        }

        public async Task<Movie> UpdateMovie(MovieDto dto, int id)
        {
            using var stream = new MemoryStream();
            await dto.Poster.CopyToAsync(stream);

            var genre = await _context.Genres.FindAsync(dto.GenreId);

            var movie = await _context.Movies.FindAsync(id);

            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.GenreId = dto.GenreId;
            movie.Rate = dto.Rate;
            movie.Year = dto.Year;
            movie.Poster = stream.ToArray();
            movie.Genre = genre;

            _context.Movies.Update(movie);
            _context.SaveChanges();

            return movie;
        }

        public async Task<bool> IsExist(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie != null;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}
