using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Serves
{
    public class GenreServes : IGenreServes
    {
        private readonly ApplicationDbContext? _context;

        public GenreServes(ApplicationDbContext? context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }


        public async Task<Genre> Create(GenreDto dto)
        {
            var genre = new Genre { Name = dto.Name };
            await _context.Genres.AddAsync(genre);
            _context.SaveChanges();
            return genre;
        }

        public async Task<Genre> Update(int id, GenreDto dto)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                genre.Name = dto.Name;

                _context.Update(genre);
                _context.SaveChanges();
            }
            
            return genre;
        }

        public async Task<Boolean> IsExist(int id)
        {
            return await _context.Genres.AnyAsync(x => x.Id == id);
        }

        public async Task<Genre> Delete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                _context.Remove(genre);
                _context.SaveChanges();
            }

            return genre;
        }
    }
}
