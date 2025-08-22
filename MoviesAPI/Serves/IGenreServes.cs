using Microsoft.AspNetCore.Http.HttpResults;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Serves
{
    public interface IGenreServes
    {
        Task<IEnumerable<Genre>> GetAll();

        Task<Genre> GetById(int id);

        Task<Genre> Create(GenreDto dto);

        Task<Genre> Update(int id ,GenreDto dto);


        Task<Boolean> IsExist(int id);

        Task<Genre> Delete(int id);


    }
}
