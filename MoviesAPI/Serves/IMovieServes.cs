using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Serves
{
    public interface IMovieServes
    {
        Task<IEnumerable<Movie>> GetAll();
        
        
        Task<Movie> GetById(int id);

        Task<IEnumerable<Movie>> GetByGenreId(int genreId);

        Task<Movie> CreateMovie(MovieDto dot);

        Task<Movie> UpdateMovie(MovieDto dot , int id);

        Task<Boolean> IsExist(int id);

        Task<Movie> DeleteMovie(int id);


    }
}
